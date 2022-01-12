using EvaluationSystem.Application.Models.AttestationModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AttestationModels.Interface
{
    public interface IAttestationService
    {
        List<AttestationGetDto> GetAll();
        AttestationGetDto Create(AttestationCreateDto model);
        void Delete(int attestationId);
    }
}
