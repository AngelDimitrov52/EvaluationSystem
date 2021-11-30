using AutoMapper;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Domain.Entities;

namespace EvaluationSystem.Application.Helpers.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionUpdateDto, QuestionTemplate>().ReverseMap();
            CreateMap<QuestionTemplate, QuestionCreateDto>().ReverseMap();
            CreateMap<QuestionTemplate, QuestionGetDto>().ReverseMap();
            CreateMap<QuestionTemplate, QuestionTemplateGetDto>().ReverseMap();
            CreateMap<QuestionTemplate, QuestionTemplateCreateDto>().ReverseMap();
            CreateMap<QuestionGetDto, QuestionTemplateGetDto>().ReverseMap();
        }
    }
}
