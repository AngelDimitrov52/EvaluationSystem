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

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<UserGetDto> GetAll()
        {
          var users =_userRepository.GetAll();
            return _mapper.Map<List<UserGetDto>>(users);
        }

    }
}
