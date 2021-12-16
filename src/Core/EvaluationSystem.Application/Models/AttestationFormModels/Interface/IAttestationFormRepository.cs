using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities.AttestationEntities;

namespace EvaluationSystem.Application.Models.AttestationFormModels.Interface
{
    public interface IAttestationFormRepository : IGenericRepository<AttestationForm>
    {
        void DeleteFormFromFormModuleTable(int formId);
    }
}
