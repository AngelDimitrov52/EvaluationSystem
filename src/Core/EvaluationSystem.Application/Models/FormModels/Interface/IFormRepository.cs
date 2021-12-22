using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.FormModels.Interface
{
    public interface IFormRepository : IGenericRepository<FormTemplate>
    {
        List<Attestation> GetAllAttestationsWithFormId(int formId);
        void DeleteFormFromFormModuleTable(int formId);
        FormTemplate GetFormByName(string name);
        FormTemplate GetFormByNameAndId(string name, int formId);
    }
}
