
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AnswerModels
{
    public interface IAnswerService
    {
        AnswerGetDto GetById(int id);
        List<AnswerGetDto> GetAll(int id);
        void Delete(int id);
        AnswerGetDto Create(int questionId, AnswerCreateDto model);
        AnswerGetDto Update(int questionId, int id, AnswerCreateDto model);
    }
}
