using AutoMapper;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Domain.Entities;
using EvaluationSystem.Domain.Entities.AttestationEntities;

namespace EvaluationSystem.Application.Helpers.Profiles
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<ModuleTemplate, ModuleGetDto>().ReverseMap();
            CreateMap<ModuleTemplate, ModuleCreateDto>().ReverseMap();
            CreateMap<ModuleGetDto, ModuleCreateDto>().ReverseMap();
            CreateMap<ModuleTemplate, ModuleUpdateDto>().ReverseMap();
            CreateMap<ModuleGetDto, ModuleAttestationDto>().ReverseMap();
            CreateMap<ModuleCreateDto, AttestationModule>().ReverseMap();
            CreateMap<ModuleGetDto, AttestationModule>().ReverseMap();
        }
    }
}
