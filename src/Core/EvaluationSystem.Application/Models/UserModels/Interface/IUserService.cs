using EvaluationSystem.Application.Models.UserModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.UserModels.Interface
{
    public interface IUserService
    {
        List<UserGetDto> GetAll();
    }
}
