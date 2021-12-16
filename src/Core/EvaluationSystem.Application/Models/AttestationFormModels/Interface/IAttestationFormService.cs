using EvaluationSystem.Application.Models.FormModels.Dtos;

namespace EvaluationSystem.Application.Models.AttestationFormModels.Interface
{
    public interface IAttestationFormService
    {
        int Create(FormCreateDto model);
        FormGetDto GetById(int formId);
        void Delete(int formId);
    }
}
