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
            CreateMap<User, CurrentUser>().ReverseMap();
            CreateMap<UserEvaluatorCreateDto, UserParticipantCreateDto>().ReverseMap();
            CreateMap<Microsoft.Graph.User, UsersFromAzure>()
                 .ForMember(q => q.Name, opts => opts.MapFrom(qd => qd.DisplayName))
                .ForMember(q => q.Email, opts => opts.MapFrom(t => t.UserPrincipalName)).ReverseMap();
        }
    }
}
