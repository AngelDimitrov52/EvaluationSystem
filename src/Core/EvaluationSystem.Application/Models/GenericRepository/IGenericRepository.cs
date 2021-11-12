using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.GenericRepository
{
    public interface IGenericRepository<T>
    {
        List<T> GetAll (int questionId);
        T GetById(int id);
        int Create(T entity);
        void Update(T entity);
        public void Delete(int id);
    }
}
