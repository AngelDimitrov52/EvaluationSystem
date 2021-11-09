using Dapper;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Application.Models.QuestionModels.QuestionRepository;
using EvaluationSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Persistence.Repositories
{
    public class QuestionDB : IQuestionRepository
    {
        private readonly IConfiguration _configuration;

        public QuestionDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Connection => new SqlConnection(_configuration.GetConnectionString("EvaluationSystemDBConnection"));

        public List<QuestionRepositoryDto> GetAll()
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"SELECT q.QuestionId, q.[Name], q.[Type],a.AnswerId, a.AnswerText , a.Position, a.IsDefault
                                 FROM AnswerTemplate AS a
                                 JOIN QuestionTemplate AS q ON q.QuestionId = a.IdQuestion";
                var result = connection.Query<QuestionRepositoryDto>(query);

                return (List<QuestionRepositoryDto>)result;
            }
        }

        public List<QuestionRepositoryDto> GetById(int id)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @$"SELECT q.QuestionId, q.[Name], q.[Type],a.AnswerId, a.AnswerText , a.Position, a.IsDefault
                                FROM AnswerTemplate AS a
                                JOIN QuestionTemplate AS q ON q.QuestionId = a.IdQuestion
                                WHERE q.QuestionId = @Id";
                var result = connection.Query<QuestionRepositoryDto>(query, new { Id = id });

                return (List<QuestionRepositoryDto>)result;
            }
        }

        public int AddNew(QuestionDbCreateDto model)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"INSERT QuestionTemplate([Name], [Type], IsReusable)  OUTPUT inserted.QuestionId VALUES (@Name, @Type, @IsReusable);";
                var index = connection.QuerySingle<int>(query, model);

                return index;
            }
        }

        public void Update(Question model)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @$"UPDATE QuestionTemplate
                                SET [Name] = @Name, IsReusable  = @IsReusable, [Type] = @Type
                                WHERE QuestionId = @QuestionId;";
                connection.Query<Question>(query, model);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"DELETE FROM QuestionTemplate WHERE QuestionId = @QuestionId";
                connection.Execute(query, new { QuestionId = id });
            }
        }

    }
}
