using AutoMapper;
using EvaluationSystem.Application.Models.Dtos;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Helpers.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionTemplate, QuestionDto>().ReverseMap();
            CreateMap<QuestionTemplate, QuestionUpdateDto>().ReverseMap();
            CreateMap<QuestionDbCreateDto, QuestionCreateDto>().ReverseMap();
            CreateMap<QuestionTemplate, QuestionCreateDto>().ReverseMap();
            CreateMap<QuestionTemplate, QuestionGetDto>().ReverseMap();
        }
    }
}
