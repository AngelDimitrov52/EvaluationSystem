using EvaluationSystem.Application.Models.GenericRepository;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EvaluationSystem.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        public UnitOfWork(IConfiguration configuration)
        {
            _connection = new SqlConnection(configuration.GetConnectionString("DatabaseConnection"));
            _connection.Open();
        }
        public IDbConnection Connection => _connection;
        public IDbTransaction Transaction => _transaction;
        public void Begin()
        {
            _transaction = _connection.BeginTransaction();
        }
        public void Commit()
        {
            _transaction.Commit();
            Dispose();
        }
        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }
        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }
    }
}
