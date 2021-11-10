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
   public abstract class BaseRepository
    {
        private readonly string _configurationString;

        public BaseRepository(IConfiguration configuration)
        {
            _configurationString = configuration.GetConnectionString("EvaluationSystemDBConnection");
        }

        public IDbConnection Connection => new SqlConnection(_configurationString);
    }
}
