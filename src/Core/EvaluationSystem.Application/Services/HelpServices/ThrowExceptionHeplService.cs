using EvaluationSystem.Application.Models.Exceptions;
using EvaluationSystem.Application.Models.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Services.HelpServices
{
    public static class ThrowExceptionHeplService
    {
        public static void ThrowExceptionWhenEntityDoNotExist<T>(int id, IGenericRepository<T> repository)
        {
            var entity = repository.GetById(id);
            var entityName = typeof(T).Name.Remove(typeof(T).Name.Length - 8);
            if (entity == null)
            {
                throw new HttpException($"{entityName} with ID:{id} doesn't exist!", HttpStatusCode.NotFound);
            }
        }
    }
}
