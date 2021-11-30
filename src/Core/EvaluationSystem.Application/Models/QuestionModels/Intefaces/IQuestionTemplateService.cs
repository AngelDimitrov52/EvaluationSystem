using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.QuestionModels
{
    public interface IQuestionTemplateService
    {
        List<QuestionTemplateGetDto> GetAll();
        QuestionTemplateGetDto GetById(int id);
        QuestionGetDto Create(QuestionCreateDto model);
        QuestionUpdateDto Update(int id, QuestionUpdateDto model);
        void Delete(int id);
        QuestionTemplate CreateQuestionAnswers(int index, QuestionTemplate model);
    }
}
