using EvaluationSystem.Application.Models.AttestationAnswerModel.Dtos;
using EvaluationSystem.Application.Models.FormModels.Dtos;

namespace EvaluationSystem.Application.Models.AttestationAnswerModel.Interface
{
    public interface IUserAnswerService
    {
        void Create(UserAnswerCreateDto attestationAnswerCreateDtos);
        FormAttestationDto GetFormWhithCurrentAnswers(int attestationId, string participantEmail);
        void DeleteWithAttestationId(int atteatationId);
    }
}
