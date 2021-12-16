using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Domain.Entities;
using EvaluationSystem.Domain.Entities.AttestationEntities;

namespace EvaluationSystem.Application.Helpers.Profiles
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<AnswerTemplate, AnswerCreateDto>().ReverseMap();
            CreateMap<AnswerTemplate, AnswerGetDto>().ReverseMap();
            CreateMap<AnswerCreateDto, AnswerGetDto>().ReverseMap();
            CreateMap<AnswerGetDto, AnswerAttestationGetDto>().ReverseMap();
            CreateMap<AnswerCreateDto, AttestationAnswer>().ReverseMap();
            CreateMap<AnswerGetDto, AttestationAnswer>().ReverseMap();
        }
    }
}
