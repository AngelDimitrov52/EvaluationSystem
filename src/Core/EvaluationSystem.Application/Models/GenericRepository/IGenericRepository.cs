using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.GenericRepository
{
    public interface IGenericRepository<T>
    {
        public void Delete(object id);
    }
}
