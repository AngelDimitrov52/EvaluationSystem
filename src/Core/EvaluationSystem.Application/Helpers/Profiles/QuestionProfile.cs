using AutoMapper;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Domain.Entities;

namespace EvaluationSystem.Application.Helpers.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionUpdateDto, QuestionTemplate>()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<QuestionTemplate, QuestionCreateDto>().ReverseMap();
            CreateMap<QuestionTemplate, QuestionGetDto>().ReverseMap();
        }
    }
}
