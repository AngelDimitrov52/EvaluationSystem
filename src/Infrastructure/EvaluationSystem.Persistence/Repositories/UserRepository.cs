using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Application.Models.UserModels.Interface;
using EvaluationSystem.Domain.Entities;

namespace EvaluationSystem.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
