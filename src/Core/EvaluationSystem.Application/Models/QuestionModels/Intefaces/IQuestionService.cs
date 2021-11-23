using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.QuestionModels
{
    public interface IQuestionService
    {
        List<QuestionGetDto> GetAll();
        QuestionGetDto GetById(int id);
        void Delete(int id);
        QuestionGetDto Create(QuestionCreateDto model);
        QuestionUpdateDto Update(int id, QuestionUpdateDto model);
        void IsQuestionExist(int questionId);
    }
}
