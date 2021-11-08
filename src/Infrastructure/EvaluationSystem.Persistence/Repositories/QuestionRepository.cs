using Dapper;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
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
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IConfiguration _configuration;

        public QuestionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Connection => new SqlConnection(_configuration.GetConnectionString("EvaluationSystemDBConnection"));

        public List<Question> GetAll()
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"SELECT * FROM QuestionTemplate";
                var result = connection.Query<Question>(query);
                return (List<Question>)result;
            }
        }

        public Question GetById(int id)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @$"SELECT * FROM QuestionTemplate WHERE Id=@Id";
                var result = connection.QueryFirst<Question>(query, new { Id = id });
                return result;
            }
        }

        public int AddNew(QuestionDbCreateDto model)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"INSERT QuestionTemplate([Name], [Type], IsReusable)  OUTPUT inserted.Id VALUES (@Name, @Type, @IsReusable);";
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
                                WHERE Id = @Id;";
                connection.Query<Question>(query, model);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"DELETE FROM QuestionTemplate WHERE Id = @Id";
                connection.Execute(query, new { Id = id });
            }
        }

    }
}
