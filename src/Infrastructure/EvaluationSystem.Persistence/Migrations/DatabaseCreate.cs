using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace EvaluationSystem.Persistence.Migrations
{
    public static class DatabaseCreate
    {
        public static void Create(string connectionString, string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("name", name);

            using var connection = new SqlConnection(connectionString);
            var records = connection.Query("SELECT * FROM sys.databases WHERE name = @name",
                 parameters);

            if (records.Any() == false)
            {
                connection.Execute($"CREATE DATABASE {name}");
            }
        }
    }
}
