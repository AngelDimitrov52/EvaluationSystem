using Dapper;
using EvaluationSystem.Application.Models.AttestationQuestionModels.Interface;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Domain.Entities.AttestationEntities;
using System.Collections.Generic;

namespace EvaluationSystem.Persistence.Repositories.AttestationRepositories
{
    public class AttestationQuestionRepository : GenericRepository<AttestationQuestion>, IAttestationQuestionRepository
    {
        public AttestationQuestionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void AddAttestationQuestionToAttestationModule(int moduleId, int questionId, int position)
        {
            var query = "Insert Into AttestationModuleQuestion (IdModule, IdQuestion, Position) Values(@IdModule, @IdQuestion, @Position)";
            Connection.Execute(query, new { IdModule = moduleId, IdQuestion = questionId, Position = position }, Transaction);
        }
        public List<ModuleQuestionTemplateDto> GetModuleQuestions(int moduleId)
        {
            string query = @"SELECT * FROM AttestationModuleQuestion WHERE IdModule = @moduleId ORDER BY [Position] ASC";
            var result = Connection.Query<ModuleQuestionTemplateDto>(query, new { moduleId = moduleId }, Transaction);
            return (List<ModuleQuestionTemplateDto>)result;
        }
        public void DeleteQuestionFromModule(int questionId)
        {
            string query = "Delete from AttestationModuleQuestion where IdQuestion = @IdQuestion";
            Connection.Execute(query, new { IdQuestion = questionId }, Transaction);
        }
    }
}
