using AutoMapper;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Domain.Entities;

namespace EvaluationSystem.Application.Helpers.Profiles
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<ModuleTemplate, ModuleGetDto>().ReverseMap();
            CreateMap<ModuleTemplate, ModuleCreateDto>().ReverseMap();
            CreateMap<ModuleTemplate, ModuleWithQuestionsDto>().ReverseMap();
        }
    }
}
