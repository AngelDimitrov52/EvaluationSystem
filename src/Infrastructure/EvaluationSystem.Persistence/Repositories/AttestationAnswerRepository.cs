using EvaluationSystem.Application.Models.AttestationAnswerModel.Interface;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;

namespace EvaluationSystem.Persistence.Repositories
{
    public class AttestationAnswerRepository : GenericRepository<AttestationAnswer>, IAttestationAnswerRepository
    {
        public AttestationAnswerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
