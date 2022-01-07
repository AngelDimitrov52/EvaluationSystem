using EvaluationSystem.Application.Models.UserModels.Dtos;
using EvaluationSystem.Application.Models.UserModels.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvaluationSystem.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public Task<List<UserGetDto>> GetAll()
        {
            return _userService.GetAll();
        }
        [HttpGet("AllUsersToEvaluation")]
        public List<UserToEvaluationDto> GetAllAttestationWithUsersToEvaluation()
        {
            return _userService.GetAllUsersToEvaluation();
        }
    }
}
