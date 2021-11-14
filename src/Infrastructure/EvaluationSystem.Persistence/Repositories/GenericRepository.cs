using Dapper;
using EvaluationSystem.Application.Models.GenericRepository;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EvaluationSystem.Persistence.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly string _configurationString;

        public GenericRepository(IConfiguration configuration)
        {
            _configurationString = configuration.GetConnectionString("DatabaseConnection");  
        }
        public IDbConnection Connection() => new SqlConnection(_configurationString);

        public List<T> GetAll(int questionId)
        {
            using var connection = Connection();
            return connection.GetList<T>().ToList();
        }
        public T GetById(int id)
        {
            using var connection = Connection();
            return connection.Get<T>(id);
        }
        public int Create(T entity)
        {
            using var connection = Connection();
            return (int)connection.Insert<T>(entity);
        }
        public void Update(T entity)
        {
            using var connection = Connection();
           connection.Update<T>(entity);
        }
        public void Delete(int id)
        {
            using var connection = Connection();
             connection.Delete<T>(id);
        }
    }
}
