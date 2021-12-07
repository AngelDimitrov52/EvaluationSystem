using EvaluationSystem.Application.Models.AttestationAnswerModel.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AttestationAnswerModel.Interface
{
    public interface IAttestationAnswerService
    {
        void Create(List<AttestationAnswerCreateDto> attestationAnswerCreateDtos);
    }
}
