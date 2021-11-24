using Dapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Persistence.Repositories
{
    public class AnswerRepository : GenericRepository<AnswerTemplate>, IAnswerRepository
    {
        public AnswerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public List<AnswerTemplate> GetAllByQuestionId(int questionId)
        {
            string query = @"SELECT * FROM AnswerTemplate WHERE IdQuestion = @questionId";
            var result = Connection.Query<AnswerTemplate>(query, new { questionId = questionId }, Transaction);
            return (List<AnswerTemplate>)result;
        }
        public void DeleteWithQuestionId(int idQuestion)
        {
            string query = @"DELETE FROM AnswerTemplate WHERE IdQuestion = @IdQuestion";
            Connection.Execute(query, new { IdQuestion = idQuestion }, Transaction);
        }
    }
}
