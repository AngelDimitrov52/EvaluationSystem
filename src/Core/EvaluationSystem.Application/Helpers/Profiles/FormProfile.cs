using AutoMapper;
using EvaluationSystem.Application.Models.FormModels.Dtos;
using EvaluationSystem.Domain.Entities;
using EvaluationSystem.Domain.Entities.AttestationEntities;

namespace EvaluationSystem.Application.Helpers.Profiles
{
    public class FormProfile : Profile
    {
        public FormProfile()
        {
            CreateMap<FormTemplate, FormGetDto>().ReverseMap();
            CreateMap<FormTemplate, FormCreateDto>().ReverseMap();
            CreateMap<FormGetDto, FormCreateDto>().ReverseMap();
            CreateMap<FormTemplate, FormUpdateDto>().ReverseMap();
            CreateMap<FormGetDto, FormAttestationDto>().ReverseMap();
            CreateMap<FormCreateDto, AttestationForm>().ReverseMap();
            CreateMap<FormGetDto, AttestationForm>().ReverseMap();
        }
    }
}
