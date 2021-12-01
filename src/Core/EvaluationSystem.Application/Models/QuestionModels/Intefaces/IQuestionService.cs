using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.QuestionModels.Intefaces
{
    public interface IQuestionService
    {
        List<QuestionGetDto> GetAll(int moduleId);
        QuestionGetDto GetById(int moduleId, int questionId);
        QuestionGetDto Create(int moduleId, QuestionCreateDto model);
        QuestionUpdateDto Update(int moduleId, int questionId, QuestionUpdateDto model);
        void Delete(int questionId);
    }
}
