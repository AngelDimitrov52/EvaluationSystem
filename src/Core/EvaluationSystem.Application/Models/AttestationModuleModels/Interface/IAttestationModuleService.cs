using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AttestationModuleModels.Interface
{
    public interface IAttestationModuleService
    {
        void Create(int formId, ModuleCreateDto model);
        List<ModuleGetDto> GetAllModules(int formId);
        void Delete(int moduleId);
    }
}
