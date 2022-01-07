using EvaluationSystem.Application.Models.UserModels.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.UserModels.Interface
{
    public interface IUserService
    {
        Task<List<UserGetDto>> GetAll();
        List<UserToEvaluationDto> GetAllUsersToEvaluation();
    }
}
