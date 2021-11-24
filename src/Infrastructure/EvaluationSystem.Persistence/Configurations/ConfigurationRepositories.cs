using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.FormModels.Interface;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using EvaluationSystem.Application.Models.QuestionModels;
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
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IFormRepository, FormRepository>();

            return services;
        }
    }
}
