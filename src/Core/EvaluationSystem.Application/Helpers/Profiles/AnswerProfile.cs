using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Domain.Entities;

namespace EvaluationSystem.Application.Helpers.Profiles
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<AnswerTemplate, AnswerCreateDto>().ReverseMap();
            CreateMap<AnswerTemplate, AnswerGetDto>().ReverseMap();
            CreateMap<AnswerGetDto, AnswerAttestationGetDto>().ReverseMap();
        }
    }
}
