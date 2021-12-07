using AutoMapper;
using EvaluationSystem.Application.Models.AttestationAnswerModel.Dtos;
using EvaluationSystem.Domain.Entities;

namespace EvaluationSystem.Application.Helpers.Profiles
{
    public class AttestationAnswerProfile : Profile
    {
        public AttestationAnswerProfile()
        {
            CreateMap<AttestationAnswerCreateDto, AttestationAnswer>().ReverseMap();
        }
    }
}
