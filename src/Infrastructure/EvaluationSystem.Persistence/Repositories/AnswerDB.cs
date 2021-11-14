using Dapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace EvaluationSystem.Persistence.Repositories
{
    public class AnswerDB : GenericRepository<AnswerTemplate>, IAnswerRepository
    {
        public AnswerDB(IConfiguration configuration) : base(configuration)
        {
        }
        public List<AnswerTemplate> GetAllByQuestionId(int questionId)
        {
            using var connection = Connection();
            string query = @"SELECT * FROM AnswerTemplate WHERE IdQuestion = @questionId";
            var result = connection.Query<AnswerTemplate>(query, new { questionId = questionId });
            return (List<AnswerTemplate>)result;
        }
        public void DeleteWithQuestionId(int idQuestion)
        {
            using var connection = Connection();
            string query = @"DELETE FROM AnswerTemplate WHERE IdQuestion = @IdQuestion";
            connection.Execute(query, new { IdQuestion = idQuestion });
        }
    }
}
