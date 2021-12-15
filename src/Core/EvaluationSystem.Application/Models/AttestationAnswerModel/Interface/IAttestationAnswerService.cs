using EvaluationSystem.Application.Models.AttestationAnswerModel.Dtos;
using EvaluationSystem.Application.Models.FormModels.Dtos;

namespace EvaluationSystem.Application.Models.AttestationAnswerModel.Interface
{
    public interface IAttestationAnswerService
    {
        void Create(AttestationAnswerCreateDto attestationAnswerCreateDtos);
        FormAttestationDto GetFormWhithCurrentAnswers(int attestationId, string participantEmail);
    }
}
