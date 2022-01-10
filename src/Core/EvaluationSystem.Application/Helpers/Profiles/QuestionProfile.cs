using AutoMapper;
using EvaluationSystem.Application.Models.AttestationQuestionModels.Dtos;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Domain.Entities;
using EvaluationSystem.Domain.Entities.AttestationEntities;

namespace EvaluationSystem.Application.Helpers.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionUpdateDto, QuestionTemplate>().ReverseMap();
            CreateMap<QuestionTemplate, QuestionCreateDto>().ReverseMap();
            CreateMap<QuestionTemplate, QuestionGetDto>().ReverseMap();
            CreateMap<QuestionCreateDto, QuestionGetDto>().ReverseMap();
            CreateMap<QuestionTemplate, QuestionTemplateUpdateDto>().ReverseMap();
            CreateMap<QuestionTemplate, QuestionTemplateGetDto>().ReverseMap();
            CreateMap<QuestionTemplate, QuestionTemplateCreateDto>().ReverseMap();
            CreateMap<QuestionGetDto, QuestionTemplateGetDto>().ReverseMap();
            CreateMap<QuestionGetDto, QuestionAttestationDto>().ReverseMap();
            CreateMap<QuestionCreateDto, AttestationQuestion>().ReverseMap();
            CreateMap<QuestionGetDto, AttestationQuestion>().ReverseMap();
        }
    }
}
