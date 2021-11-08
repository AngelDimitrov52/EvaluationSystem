using Dapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
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
    public class AnswerDbRepository : IAnswerRepository
    {
        private readonly IConfiguration _configuration;
        public AnswerDbRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection Connection => new SqlConnection(_configuration.GetConnectionString("BooksDBConnection"));

        public void AddNew(AnswerCreateDbDto model)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"INSERT AnswerTemplate(AnswerText,IdQuestion,Position,IsDefault) VALUES (@AnswerText,@IdQuestion,@Position,@IsDefault);";
                connection.Execute(query, model);
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"DELETE FROM AnswerTemplate WHERE Id = @Id";
                connection.Execute(query, new { Id = id });
            }
        }

        public List<Аnswer> GetAll()
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"SELECT * FROM AnswerTemplate";
                var result = connection.Query<Аnswer>(query);
                return (List<Аnswer>)result;
            }
        }

        public Аnswer GetById(int id)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @$"SELECT * FROM AnswerTemplate WHERE Id=@Id";
                var result = connection.QueryFirst<Аnswer>(query, new { Id = id });
                return result;
            }
        }

        public void Update(Аnswer model)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @$"UPDATE AnswerTemplate
                                SET IsDefault = @IsDefault, Position  = @Position, AnswerText = @AnswerText ,IdQuestion = @IdQuestion
                                WHERE Id = @Id;";
                connection.Query<Аnswer>(query, model);
            }
        }
        public List<Аnswer> GetAllAnswerByQuestionId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
