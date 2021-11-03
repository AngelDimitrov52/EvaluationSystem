﻿using AutoMapper;
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
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<Question, QuestionUpdateDto>().ReverseMap();
            CreateMap<Question, QuestionCreateDto>().ReverseMap();
            CreateMap<Question, QuestionGetDto>().ReverseMap();
        }
    }
}
