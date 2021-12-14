using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;

namespace EvaluationSystem.Application.Models.AttestationAnswerModel.Interface
{
    public interface IAttestationAnswerRepository : IGenericRepository<AttestationAnswer>
    {
        void ChangeUserStatusToDone(int attestationId, int userId);
    }
}
