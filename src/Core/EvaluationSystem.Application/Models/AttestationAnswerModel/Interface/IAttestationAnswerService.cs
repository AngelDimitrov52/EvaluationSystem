using EvaluationSystem.Application.Models.AttestationAnswerModel.Dtos;

namespace EvaluationSystem.Application.Models.AttestationAnswerModel.Interface
{
    public interface IAttestationAnswerService
    {
        void Create(AttestationAnswerCreateDto attestationAnswerCreateDtos);
    }
}
