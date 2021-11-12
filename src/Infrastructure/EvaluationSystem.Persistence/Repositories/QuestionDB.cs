using Dapper;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace EvaluationSystem.Persistence.Repositories
{
    public class QuestionDB : GenericRepository<Question>, IQuestionRepository
    {

        private const string _tableName = "QuestionTemplate";
        private const string _objIdName = "QuestionId";
        public QuestionDB(IConfiguration configuration) : base(configuration, _tableName, _objIdName)
        { 
        }
        public List<QuestionRepositoryDto> GetAll()
        {
            using var connection = Connection;
            string query = @"SELECT q.QuestionId, q.[Name], q.[Type],a.AnswerId, a.AnswerText , a.Position, a.IsDefault
                                 FROM AnswerTemplate AS a
                                 RIGHT JOIN QuestionTemplate AS q ON q.QuestionId = a.IdQuestion";
            var result = connection.Query<QuestionRepositoryDto>(query);
            return (List<QuestionRepositoryDto>)result;
        }

        public List<QuestionRepositoryDto> GetById(int id)
        {
            using var connection = Connection;
            string query = @$"SELECT q.QuestionId, q.[Name], q.[Type],a.AnswerId, a.AnswerText , a.Position, a.IsDefault
                                FROM AnswerTemplate AS a
                                RIGHT JOIN QuestionTemplate AS q ON q.QuestionId = a.IdQuestion
                                WHERE q.QuestionId = @Id";
            var result = connection.Query<QuestionRepositoryDto>(query, new { Id = id });
            return (List<QuestionRepositoryDto>)result;
        }

        public int AddNew(QuestionDbCreateDto model)
        {
            using var connection = Connection;
            string query = @"INSERT QuestionTemplate([Name], [Type], IsReusable)  OUTPUT inserted.QuestionId VALUES (@Name, @Type, @IsReusable);";
            var index = connection.QuerySingle<int>(query, model);
            return index;
        }

        public void Update(Question model)
        {
            using var connection = Connection;
            string query = @$"UPDATE QuestionTemplate
                                SET [Name] = @Name, IsReusable  = @IsReusable, [Type] = @Type
                                WHERE QuestionId = @QuestionId;";
            connection.Query<Question>(query, model);
        }
        //public void Delete(int id)
        //{
        //    using var connection = Connection;
        //    string query = @"DELETE FROM QuestionTemplate WHERE QuestionId = @QuestionId";
        //    connection.Execute(query, new { QuestionId = id });
        //}
    }
}
