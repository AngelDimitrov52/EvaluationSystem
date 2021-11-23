using Dapper;
using EvaluationSystem.Application.Models.FormModels.Dtos;
using EvaluationSystem.Application.Models.FormModels.Interface;
using EvaluationSystem.Application.Models.GenericRepository;
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
        public FormDB(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public void AddModuleToForm(int formId, int moduleId, int position)
        {
            string query = "Insert Into FormModule (IdForm, IdModule, Position) Values(@IdForm, @IdModule, @Position)";
            Connection.Execute(query, new { IdForm = formId, IdModule = moduleId, Position = position }, Transaction);
        }

        public void DeleteModuleFromForm(int formId, int moduleId)
        {
            string query = "Delete from FormModule where IdForm = @IdForm AND IdModule = @IdModule";
            Connection.Execute(query, new { IdForm = formId, IdModule = moduleId }, Transaction);
        }

        public List<FormModuleTemplateDto> GetFormModules(int formId)
        {
            string query = @"SELECT * FROM FormModule WHERE IdForm = @IdForm ORDER BY [Position] ASC";
            var result = Connection.Query<FormModuleTemplateDto>(query, new { IdForm = formId }, Transaction);
            return (List<FormModuleTemplateDto>)result;
        }
    }
}
