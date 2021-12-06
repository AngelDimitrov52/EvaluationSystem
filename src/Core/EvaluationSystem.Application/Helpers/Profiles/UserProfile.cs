using AutoMapper;
using EvaluationSystem.Application.Models.UserModels.Dtos;
using EvaluationSystem.Domain.Entities;

namespace EvaluationSystem.Application.Helpers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserGetDto>().ReverseMap();
        }
    }
}
