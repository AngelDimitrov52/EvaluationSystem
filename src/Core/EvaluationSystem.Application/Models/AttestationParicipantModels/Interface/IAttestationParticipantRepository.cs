using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AttestationParicipantModels.Interface
{
    public interface IAttestationParticipantRepository : IGenericRepository<AttestationParticipant>
    {
        List<AttestationParticipant> GetAllUserParticipatnByAttestationId(int attestationId);
        AttestationParticipant GetAllParticipantFormId(int attestationId, int userId);

    }
}
