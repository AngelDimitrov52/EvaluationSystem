using EvaluationSystem.Application.Models.AttestationModels.Dtos;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.AttestationModels.Interface
{
    public interface IAttestationRepository : IGenericRepository<Attestation>
    {
        List<AttestationFromDbDto> GetAllAttestations();
        void AddParticipantToAttestation(int attestationId ,int participantId,string position);
        void DeleteAttestationFromAttestationParticipant(int attestationId);
        void DeleteAttestationFromAttestationTable(int attestationId);
    }
}
