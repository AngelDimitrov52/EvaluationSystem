
using Dapper;
using EvaluationSystem.Application.Models.GenericRepository;
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
    public class ModuleRepository : GenericRepository<ModuleTemplate>, IModuleRepository
    {
        public ModuleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public void AddQuestionToModule(int moduleId, int questionId, int position)
        {
            string query = "Insert Into ModuleQuestion (IdModule, IdQuestion, Position) Values(@IdModule, @IdQuestion, @Position)";
            Connection.Execute(query, new { IdModule = moduleId, IdQuestion = questionId, Position = position }, Transaction);
        }

        public void DeleteQuestionFromModule(int moduleId, int questionId)
        {
            string query = "Delete from ModuleQuestion where IdQuestion = @IdQuestion AND IdModule = @IdModule";
            Connection.Execute(query, new { IdModule = moduleId, IdQuestion = questionId }, Transaction);
        }

        public List<ModuleQuestionTemplateDto> GetModuleQuestions(int moduleId)
        {
            string query = @"SELECT * FROM ModuleQuestion WHERE IdModule = @moduleId ORDER BY [Position] ASC";
            var result = Connection.Query<ModuleQuestionTemplateDto>(query, new { moduleId = moduleId }, Transaction);
            return (List<ModuleQuestionTemplateDto>)result;
        }
    }
}
