using EvaluationSystem.Application.Models.FormModels.Interface;
using EvaluationSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Persistence.Repositories
{
   public class FormDB : GenericRepository<FormTemplate>, IFormRepository
    {
        public FormDB(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
