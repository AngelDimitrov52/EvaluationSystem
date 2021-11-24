using Dapper;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Persistence.Repositories
{
    public class QuestionRepository : GenericRepository<QuestionTemplate>, IQuestionRepository
    {
        public QuestionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public List<QuestionRepositoryDto> GetAllQuestions()
        {
            string query = @"SELECT q.Id AS QuestionId, q.[Name],q.IsReusable, q.[Type],a.Id AS AnswerId, a.AnswerText , a.Position, a.IsDefault
                                 FROM AnswerTemplate AS a
                                 RIGHT JOIN QuestionTemplate AS q ON q.Id = a.IdQuestion";
            var result = Connection.Query<QuestionRepositoryDto>(query, null, Transaction);
            return (List<QuestionRepositoryDto>)result;
        }
        public List<QuestionRepositoryDto> GetQuestionById(int id)
        {
            string query = @$"SELECT q.Id AS QuestionId, q.[Name],q.IsReusable, q.[Type],a.Id AS AnswerId, a.AnswerText , a.Position, a.IsDefault
                                FROM AnswerTemplate AS a
                                RIGHT JOIN QuestionTemplate AS q ON q.Id = a.IdQuestion
                                WHERE q.Id = @Id";
            var result = Connection.Query<QuestionRepositoryDto>(query, new { Id = id }, Transaction);
            return (List<QuestionRepositoryDto>)result;
        }
        public void DeleteQuestionFromModuleQuestionTable( int questionId)
        {
            string query = "Delete from ModuleQuestion where IdQuestion = @IdQuestion ";
            Connection.Execute(query, new { IdQuestion = questionId }, Transaction);
        }
    }
}
