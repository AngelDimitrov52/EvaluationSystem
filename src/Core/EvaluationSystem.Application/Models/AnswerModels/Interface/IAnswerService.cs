
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AnswerModels
{
    public interface IAnswerService
    {
        AnswerGetDto GetById(int questionId, int id);
        List<AnswerGetDto> GetAll(int id);
        void Delete(int id);
        AnswerGetDto Create(int questionId, AnswerCreateDto model);
        AnswerGetDto Update(int questionId, int id, AnswerCreateDto model);

    }
}
