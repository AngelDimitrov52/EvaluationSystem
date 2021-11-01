using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Helpers.Profiles
{
   public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<Аnswer, AnswerDto>().ReverseMap();
        }
    }
}
