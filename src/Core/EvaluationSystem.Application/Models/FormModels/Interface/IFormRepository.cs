using EvaluationSystem.Application.Models.FormModels.Dtos;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.FormModels.Interface
{
    public interface IFormRepository : IGenericRepository<FormTemplate>
    {
        void DeleteFormFromFormModuleTable(int formId);
    }
}
