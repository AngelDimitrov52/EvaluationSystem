using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.ModuleModels.Interface
{
    public interface IModuleService
    {
        List<ModuleGetDto> GetAllModules(int formId);
        ModuleGetDto GetById(int formId, int moduleId);
        ModuleGetDto Create(int formId, ModuleCreateDto model);
        ModuleUpdateDto Update(int formId, int moduleId, ModuleUpdateDto model);
        void Delete(int moduleId);
    }
}
