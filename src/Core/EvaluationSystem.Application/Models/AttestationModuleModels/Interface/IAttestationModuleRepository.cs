using EvaluationSystem.Application.Models.FormModels.Dtos;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities.AttestationEntities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AttestationModuleModels.Interface
{
    public interface IAttestationModuleRepository : IGenericRepository<AttestationModule>
    {
        void AddAttestationModuleToAttestatationForm(int formId, int moduleId, int position);
        List<FormModuleTemplateDto> GetFormModulesByFormId(int formId);
        void DeleteModuleFromFormModuleTable(int moduleId);
        void DeleteModuleFromModuleQuestionTable(int moduleId);
    }
}
