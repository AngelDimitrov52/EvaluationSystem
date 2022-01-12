using EvaluationSystem.Application.Models.AttestationModels.Dtos;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AttestationModels.Interface
{
    public interface IAttestationRepository : IGenericRepository<Attestation>
    {
        List<AttestationFromDbDto> GetAllAttestations();
        void AddParticipantToAttestation(int attestationId, int participantId, string position, int attestationFormId);
        void DeleteAttestationFromAttestationParticipant(int attestationId);
    }
}
