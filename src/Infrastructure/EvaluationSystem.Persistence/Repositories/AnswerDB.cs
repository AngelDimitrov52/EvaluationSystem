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
    public class AnswerDB : BaseRepository, IAnswerRepository
    {
        public AnswerDB(IConfiguration configuration)
            : base(configuration) { }

        public List<Аnswer> GetAll(int questionId)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"SELECT * FROM AnswerTemplate WHERE IdQuestion = @questionId";
                var result = connection.Query<Аnswer>(query, new { questionId = questionId });

                return (List<Аnswer>)result;
            }
        }

        public Аnswer GetById(int id)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @$"SELECT * FROM AnswerTemplate WHERE AnswerId=@Id";
                var result = connection.QueryFirst<Аnswer>(query, new { Id = id });

                return result;
            }
        }

        public int AddNew(AnswerCreateDbDto model)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"INSERT AnswerTemplate(AnswerText,IdQuestion,Position,IsDefault) OUTPUT inserted.AnswerId VALUES (@AnswerText,@IdQuestion,@Position,@IsDefault);";
                var index = connection.QuerySingle<int>(query, model);

                return index;
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"DELETE FROM AnswerTemplate WHERE AnswerId = @Id";
                connection.Execute(query, new { Id = id });
            }
        }
        public void DeleteWithQuestionId(int id)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"DELETE FROM AnswerTemplate WHERE IdQuestion = @IdQuestion";
                connection.Execute(query, new { IdQuestion = id });
            }
        }

        public void Update(Аnswer model)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @$"UPDATE AnswerTemplate
                                SET IsDefault = @IsDefault, Position  = @Position, AnswerText = @AnswerText ,IdQuestion = @IdQuestion
                                WHERE AnswerId = @AnswerId;";
                connection.Query<Аnswer>(query, model);
            }
        }

    }
}
