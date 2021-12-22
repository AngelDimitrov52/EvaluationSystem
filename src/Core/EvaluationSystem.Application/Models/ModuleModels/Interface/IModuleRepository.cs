using EvaluationSystem.Application.Models.FormModels.Dtos;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.ModuleModels.Interface
{
    public interface IModuleRepository : IGenericRepository<ModuleTemplate>
    {
        void AddModuleToForm(int moduleId, int questionId, int position);
        List<FormModuleTemplateDto> GetFormModulesByFormId(int formId);
        void DeleteModuleFromFormModuleTable(int moduleId);
        void DeleteModuleFromModuleQuestionTable(int moduleId);
        void UpdateModulePosition(int formId, int moduleId, int position);
        ModuleTemplate GetAllModulesWithModileIdFormIdModuleName(int formId, int moduleId, string moduleName);
    }
}
