using EvaluationSystem.Application.Helpers.Profiles;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.FormModels.Interface;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Services;
using EvaluationSystem.Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Helpers.Configurations
{
    public static class ConfigurationApplicationLayer
    {
        public static IServiceCollection AddConfigurationApplicationLayer(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(validator => validator.RegisterValidatorsFromAssemblyContaining<AnswerDtoValidator>());

            services.AddAutoMapper(typeof(AnswerProfile).Assembly);

            services.AddMemoryCache();

            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IFormService, FormService>();

            return services;
        }
    }
}
