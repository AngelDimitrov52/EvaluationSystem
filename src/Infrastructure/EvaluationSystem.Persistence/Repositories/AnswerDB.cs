using Dapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace EvaluationSystem.Persistence.Repositories
{
    public class AnswerDB : GenericRepository<Аnswer>, IAnswerRepository
    {
        private const string _tableName = "AnswerTemplate";
        private const string _objIdName = "AnswerId";
        public AnswerDB(IConfiguration configuration) : base(configuration, _tableName, _objIdName)
        {
        }
        public List<Аnswer> GetAll(int questionId)
        {
            using var connection = Connection;
            string query = @"SELECT * FROM AnswerTemplate WHERE IdQuestion = @questionId";
            var result = connection.Query<Аnswer>(query, new { questionId = questionId });
            return (List<Аnswer>)result;
        }

        public Аnswer GetById(int id)
        {
            using var connection = Connection;
            string query = @$"SELECT * FROM AnswerTemplate WHERE AnswerId=@Id";
            var result = connection.QueryFirst<Аnswer>(query, new { Id = id });
            return result;
        }

        public int AddNew(AnswerCreateDbDto model)
        {
            using var connection = Connection;
            string query = @"INSERT AnswerTemplate(AnswerText,IdQuestion,Position,IsDefault) OUTPUT inserted.AnswerId VALUES (@AnswerText,@IdQuestion,@Position,@IsDefault);";
            var index = connection.QuerySingle<int>(query, model);
            return index;
        }
        public void DeleteWithQuestionId(int idQuestion)
        {
            using var connection = Connection;
            string query = @"DELETE FROM AnswerTemplate WHERE IdQuestion = @IdQuestion";
            connection.Execute(query, new { IdQuestion = idQuestion });
        }

        public void Update(Аnswer model)
        {
            using var connection = Connection;
            string query = @$"UPDATE AnswerTemplate
                              SET IsDefault = @IsDefault, Position  = @Position, AnswerText = @AnswerText ,IdQuestion = @IdQuestion
                              WHERE AnswerId = @AnswerId;";
            connection.Query<Аnswer>(query, model);
        }

        //public void Delete(int id)
        //{
        //    using var connection = Connection;
        //    string query = @"DELETE FROM AnswerTemplate WHERE AnswerId = @Id";
        //    connection.Execute(query, new { Id = id });
        //}
    }
}
