using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Persistence.Configurations
{
    public static class ConfigurationRepositories
    {
        public static IServiceCollection AddConfigurationRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAnswerRepository, AnswerDB>();
            services.AddScoped<IQuestionRepository, QuestionDB>();

            return services;
        }
    }
}
