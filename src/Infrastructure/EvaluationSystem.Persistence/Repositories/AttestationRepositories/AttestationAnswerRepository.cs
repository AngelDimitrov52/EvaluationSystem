using Dapper;
using EvaluationSystem.Application.Models.AttestationAnswerModels.Interface;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using EvaluationSystem.Domain.Entities.AttestationEntities;
using System.Collections.Generic;

namespace EvaluationSystem.Persistence.Repositories.AttestationRepositories
{
    public class AttestationAnswerRepository : GenericRepository<AttestationAnswer>, IAttestationAnswerRepository
    {
        public AttestationAnswerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public List<AnswerTemplate> GetAllByQuestionId(int questionId)
        {
            string query = @"SELECT * FROM AttestationAnswer WHERE IdQuestion = @questionId";
            var result = Connection.Query<AnswerTemplate>(query, new { questionId = questionId }, Transaction);
            return (List<AnswerTemplate>)result;
        }
        public void DeleteWithQuestionId(int idQuestion)
        {
            string query = @"DELETE FROM AttestationAnswer WHERE [IdQuestion] = @IdQuestion";
            Connection.Execute(query, new { IdQuestion = idQuestion }, Transaction);
        }
    }
}
