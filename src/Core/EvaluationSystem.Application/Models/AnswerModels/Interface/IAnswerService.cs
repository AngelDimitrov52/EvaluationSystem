using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AnswerModels
{
    public interface IAnswerService
    {
        AnswerGetDto GetById(int answerId);
        List<AnswerGetDto> GetAll(int questionId);
        AnswerGetDto Create(int questionId, AnswerCreateDto model);
        AnswerGetDto Update(int questionId, int answerId, AnswerCreateDto model);
        void Delete(int answerId);
    }
}
