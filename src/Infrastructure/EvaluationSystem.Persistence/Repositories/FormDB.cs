using Dapper;
using EvaluationSystem.Application.Models.FormModels.Dtos;
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
        public void AddModuleToForm(int formId, int moduleId, int position)
        {
            using var connection = Connection();
            string query = "Insert Into FormModule (IdForm, IdModule, Position) Values(@IdForm, @IdModule, @Position)";
            int index = connection.Execute(query, new { IdForm = formId, IdModule = moduleId, Position = position });
        }

        public void DeleteModuleFromForm(int formId, int moduleId)
        {
            using var connection = Connection();
            string query = "Delete from FormModule where IdForm = @IdForm AND IdModule = @IdModule";
            int index = connection.Execute(query, new { IdForm = formId, IdModule = moduleId });
        }

        public List<FormModuleTemplateDto> GetFormModules(int formId)
        {
            using var connection = Connection();
            string query = @"SELECT * FROM FormModule WHERE IdForm = @IdForm ORDER BY [Position] ASC";
            var result = connection.Query<FormModuleTemplateDto>(query, new { IdForm = formId });
            return (List<FormModuleTemplateDto>)result;
        }
    }
}
