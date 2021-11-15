using Dapper;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace EvaluationSystem.Persistence.Repositories
{
    public class QuestionDB : GenericRepository<QuestionTemplate>, IQuestionRepository
    {
        public QuestionDB(IConfiguration configuration) : base(configuration)
        { 
        }
        public List<QuestionRepositoryDto> GetAllQuestions()
        {
            using var connection = Connection();
            string query = @"SELECT q.Id AS QuestionId, q.[Name],q.IsReusable, q.[Type],a.Id AS AnswerId, a.AnswerText , a.Position, a.IsDefault
                                 FROM AnswerTemplate AS a
                                 RIGHT JOIN QuestionTemplate AS q ON q.Id = a.IdQuestion";
            var result = connection.Query<QuestionRepositoryDto>(query);
            return (List<QuestionRepositoryDto>)result;
        }
        public List<QuestionRepositoryDto> GetQuestionById(int id)
        {
            using var connection = Connection();
            string query = @$"SELECT q.Id AS QuestionId, q.[Name],q.IsReusable, q.[Type],a.Id AS AnswerId, a.AnswerText , a.Position, a.IsDefault
                                FROM AnswerTemplate AS a
                                RIGHT JOIN QuestionTemplate AS q ON q.Id = a.IdQuestion
                                WHERE q.Id = @Id";
            var result = connection.Query<QuestionRepositoryDto>(query, new { Id = id });
            return (List<QuestionRepositoryDto>)result;
        }
    }
}
