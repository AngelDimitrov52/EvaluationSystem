using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.QuestionModels
{
    public interface IQuestionTemplateService
    {
        List<QuestionTemplateGetDto> GetAll();
        QuestionTemplateGetDto GetById(int questionId);
        QuestionTemplateGetDto Create(QuestionTemplateCreateDto model);
        QuestionUpdateDto Update(int questionId, QuestionUpdateDto model);
        void Delete(int questionId);
        QuestionTemplate CreateQuestionAnswers(int questionId, QuestionTemplate model);
    }
}
