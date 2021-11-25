using EvaluationSystem.Application.Models.FormModels.Dtos;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.FormModels.Interface
{
    public interface IFormRepository : IGenericRepository<FormTemplate>
    {
        void AddModuleToForm(int formId, int moduleId, int position);
        void DeleteModuleFromForm(int formId, int moduleId);
        List<FormModuleTemplateDto> GetFormModules(int formId);
        void EditModulePosition(int formId, int moduleId, int position);

    }
}
