using EvaluationSystem.Application.Models.Exceptions;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;
using System.Net;

namespace EvaluationSystem.Application.Services.HelpServices
{
    public static class ThrowExceptionHeplService
    {
        public static void ThrowExceptionWhenEntityDoNotExist<T>(int id, IGenericRepository<T> repository)
        {
            var entity = repository.GetById(id);
            var entityName = typeof(T).Name.Remove(typeof(T).Name.Length - 8);
            if (entity == null)
            {
                throw new HttpException($"{entityName} with ID:{id} doesn't exist!", HttpStatusCode.NotFound);
            }
        }
        public static void ThrowExceptionWhenAnsersIsNotNumericalOptions(List<AnswerTemplate> answers)
        {
            foreach (var answer in answers)
            {
                int numericValue;
                bool isInt = int.TryParse(answer.AnswerText, out numericValue);
                if (isInt == false)
                {
                    throw new HttpException("Answer is not NumericalOptions!", HttpStatusCode.BadRequest);
                }
            }
        }
    }
}
