using Dapper;
using EvaluationSystem.Application.Models.GenericRepository;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EvaluationSystem.Persistence.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly string _configurationString;
        private readonly string _table;
        private readonly string _objIdName;

        public GenericRepository(IConfiguration configuration, string table, string objIdName)
        {
            _configurationString = configuration.GetConnectionString("DatabaseConnection");
            _table = table;
            _objIdName = objIdName;
        }
        public IDbConnection Connection => new SqlConnection(_configurationString);

        public void Delete(object id)
        {
            using var connection = Connection;
            string query = @$"DELETE FROM {_table} WHERE {_objIdName} = @Id";
            connection.Execute(query, new { Id = id });
        }
    }
}
