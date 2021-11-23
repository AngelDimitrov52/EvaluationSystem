
using Dapper;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using EvaluationSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Persistence.Repositories
{
    public class ModuleDB : GenericRepository<ModuleTemplate>, IModuleRepository
    {
        public ModuleDB(IConfiguration configuration) : base(configuration)
        {
        }
        public void AddQuestionToModule(int moduleId, int questionId, int position)
        {
            using var connection = Connection();
            string query = "Insert Into ModuleQuestion (IdModule, IdQuestion, Position) Values(@IdModule, @IdQuestion, @Position)";
            int index = connection.Execute(query, new { IdModule = moduleId, IdQuestion = questionId, Position = position });
        }

        public void DeleteQuestionFromModule(int moduleId, int questionId)
        {
            using var connection = Connection();
            string query = "Delete from ModuleQuestion where IdQuestion = @IdQuestion AND IdModule = @IdModule";
            int index = connection.Execute(query, new { IdModule = moduleId, IdQuestion = questionId });
        }

        public List<ModuleQuestionTemplateDto> GetModuleQuestions(int moduleId)
        {
            using var connection = Connection();
            string query = @"SELECT * FROM ModuleQuestion WHERE IdModule = @moduleId ORDER BY [Position] ASC";
            var result = connection.Query<ModuleQuestionTemplateDto>(query, new { moduleId = moduleId });
            return (List<ModuleQuestionTemplateDto>)result;
        }
    }
}
