using EvaluationSystem.Application.Helpers.Profiles;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AttestationModels.Interface;
using EvaluationSystem.Application.Models.FormModels.Interface;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Intefaces;
using EvaluationSystem.Application.Models.UserModels.Interface;
using EvaluationSystem.Application.Services;
using EvaluationSystem.Application.Validators;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace EvaluationSystem.Application.Helpers.Configurations
{
    public static class ConfigurationApplicationLayer
    {
        public static IServiceCollection AddConfigurationApplicationLayer(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(validator => validator.RegisterValidatorsFromAssemblyContaining<AnswerDtoValidator>());

            services.AddAutoMapper(typeof(AnswerProfile).Assembly);

            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IQuestionTemplateService, QuestionTemplateService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IFormService, FormService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAttestationService, AttestationService>();

            return services;
        }
    }
}
