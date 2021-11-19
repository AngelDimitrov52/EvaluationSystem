using AutoMapper;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
