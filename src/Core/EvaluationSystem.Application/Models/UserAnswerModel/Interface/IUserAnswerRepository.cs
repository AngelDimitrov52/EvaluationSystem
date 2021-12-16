using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AttestationAnswerModel.Interface
{
    public interface IUserAnswerRepository : IGenericRepository<UserAnswer>
    {
        void ChangeUserStatusToDone(int attestationId, int userId);
        List<UserAnswer> GetAllAttestationAnswerByUserAndAttestation(int attestationId, int userId);
        void DeleteWithAttestationId(int atteatationId);
    }
}
