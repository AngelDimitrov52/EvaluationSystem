using Dapper;
using EvaluationSystem.Application.Models.FormModels.Dtos;
using EvaluationSystem.Application.Models.FormModels.Interface;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Persistence.Repositories
{
    public class FormRepository : GenericRepository<FormTemplate>, IFormRepository
    {
        public FormRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public void DeleteFormFromFormModuleTable(int formId)
        {
            string query = @"Delete from FormModule where IdForm = @IdForm";
            Connection.Execute(query, new { IdForm = formId }, Transaction);
        }
    }
}
