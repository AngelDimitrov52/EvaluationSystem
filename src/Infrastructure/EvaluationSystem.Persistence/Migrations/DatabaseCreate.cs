using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace EvaluationSystem.Persistence.Migrations
{
    public static class DatabaseCreate
    {
        public static void Create(IConfiguration configuration)
        {
            var evaluationConnectionString = new SqlConnectionStringBuilder(configuration.GetConnectionString("DatabaseConnection"));
            string dbName = evaluationConnectionString.InitialCatalog;

            var parameters = new DynamicParameters();
            parameters.Add("name", dbName);

            using var connection = new SqlConnection(configuration.GetConnectionString("MigrationString"));
            var records = connection.Query("SELECT * FROM sys.databases WHERE name = @name",
                 parameters);

            if (records.Any() == false)
            {
                connection.Execute($"CREATE DATABASE {dbName}");
            }
        }
    }
}
