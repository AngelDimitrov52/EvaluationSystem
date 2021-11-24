using AutoMapper;
using EvaluationSystem.Application.Models.FormModels.Dtos;
using EvaluationSystem.Domain.Entities;

namespace EvaluationSystem.Application.Helpers.Profiles
{
    public class FormProfile : Profile
    {
        public FormProfile()
        {
            CreateMap<FormTemplate, FormGetDto>().ReverseMap();
            CreateMap<FormTemplate, FormCreateDto>().ReverseMap();
            CreateMap<FormTemplate, FormWithModulesAndQuestionsDto>().ReverseMap();
            CreateMap<FormTemplate, FormWithModulesDto>().ReverseMap();
        }
    }
}
