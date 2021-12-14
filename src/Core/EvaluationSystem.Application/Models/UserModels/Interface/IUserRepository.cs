using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Application.Models.UserModels.Dtos;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.UserModels.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        List<UserToEvaluationDto> GetAllAttestationWithUsersToEvaluation(int participantId);
        User GetUserByEmail(string email);
    }
}
