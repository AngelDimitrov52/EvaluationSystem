﻿using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.QuestionModels
{
    public interface IQuestionRepository
    {
        Question GetById(int id);
        List<Question> GetAll();
        void Delete(int id);
        int AddNew(QuestionDbCreateDto model);
        void Update(Question model);
    }
}
