using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AttestationAnswerModel.Interface;
using EvaluationSystem.Application.Models.AttestationModels.Interface;
using EvaluationSystem.Application.Models.FormModels.Interface;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using EvaluationSystem.Application.Models.QuestionModels.Intefaces;
using EvaluationSystem.Application.Models.UserModels.Interface;
using EvaluationSystem.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EvaluationSystem.Persistence.Configurations
{
    public static class ConfigurationRepositories
    {
        public static IServiceCollection AddConfigurationRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IFormRepository, FormRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAttestationRepository, AttestationRepository>();
            services.AddScoped<IAttestationAnswerRepository, AttestationAnswerRepository>();

            return services;
        }
    }
}
