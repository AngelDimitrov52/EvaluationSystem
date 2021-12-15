using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AttestationAnswerModel.Interface
{
    public interface IAttestationAnswerRepository : IGenericRepository<AttestationAnswer>
    {
        void ChangeUserStatusToDone(int attestationId, int userId);
        List<AttestationAnswer> GetAllAttestationAnswerByUserAndAttestation(int attestationId, int userId);
    }
}
