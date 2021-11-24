using EvaluationSystem.Application.Models.Exceptions;
using EvaluationSystem.Application.Models.GenericRepository;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUnitOfWork unitOfWork)
        {
            try
            {
                unitOfWork.Begin();
                await _next.Invoke(context);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                _logger.LogError(ex.ToString());
                await ExceptionHandler(ex, context);
            }
        }

        private async Task ExceptionHandler(Exception ex, HttpContext context)
        {
            var errors = new List<ErrorModel>();

            switch (ex)
            {
                case HttpException httpException:
                    errors.Add(new ErrorModel { Code = (int)httpException.StatusCode, ErrorMessage = httpException.Message });
                    break;
                case ValidationException validationException:
                    errors.AddRange(validationException.Errors.Select(e => new ErrorModel { Code = 400, ErrorMessage = e.ErrorMessage }));
                    break;
                default:
                    errors.Add(new ErrorModel { Code = 500, ErrorMessage = ex.Message });
                    break;
            }

            var errorResponce = JsonSerializer.Serialize(errors);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = errors[0].Code;
            await context.Response.WriteAsync(errorResponce);
        }
    }
}
