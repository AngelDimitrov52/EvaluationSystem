using AutoMapper;
using EvaluationSystem.Application.Models.UserModels.Dtos;
using EvaluationSystem.Application.Models.UserModels.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUser _currentUser;

        public UserService(IUserRepository userRepository, ICurrentUser currentUser, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public List<UserGetDto> GetAll()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<List<UserGetDto>>(users);
        }
        public List<UserToEvaluationDto> GetAllUsersToEvaluation()
        {
            int id = _currentUser.Id;
            return _userRepository.GetAllAttestationWithUsersToEvaluation(id);
        }
    }
}
