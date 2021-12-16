using EvaluationSystem.Application.Helpers.Profiles;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AttestationAnswerModel.Interface;
using EvaluationSystem.Application.Models.AttestationAnswerModels.Interface;
using EvaluationSystem.Application.Models.AttestationFormModels.Interface;
using EvaluationSystem.Application.Models.AttestationModels.Interface;
using EvaluationSystem.Application.Models.AttestationModuleModels.Interface;
using EvaluationSystem.Application.Models.AttestationQuestionModels.Interface;
using EvaluationSystem.Application.Models.FormModels.Interface;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Intefaces;
using EvaluationSystem.Application.Models.UserModels.Dtos;
using EvaluationSystem.Application.Models.UserModels.Interface;
using EvaluationSystem.Application.Services;
using EvaluationSystem.Application.Services.AttestationServices;
using EvaluationSystem.Application.Validators;
using EvaluationSystem.Domain.Entities;
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

            services.AddScoped<IAttestationAnswerService, AttestationAnswerService>();
            services.AddScoped<IAttestationQuestionService, AttestationQuestionService>();
            services.AddScoped<IAttestationModuleService, AttestationModuleService>();
            services.AddScoped<IAttestationFormService, AttestationFormService>();

            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IQuestionTemplateService, QuestionTemplateService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IFormService, FormService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAttestationService, AttestationService>();
            services.AddScoped<IUserAnswerService, UserAnswerService>();
            services.AddScoped<ICurrentUser, CurrentUser>();

            return services;
        }
    }
}
