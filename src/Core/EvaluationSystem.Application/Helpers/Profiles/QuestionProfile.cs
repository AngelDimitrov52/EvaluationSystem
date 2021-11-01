using AutoMapper;
using EvaluationSystem.Application.Models.Dtos;
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
            CreateMap<QuestionEntity, QuestionDto>().ReverseMap();
        }
    }
}
