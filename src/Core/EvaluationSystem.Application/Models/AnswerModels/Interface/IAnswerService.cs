
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AnswerModels
{
    public interface IAnswerService
    {
        AnswerGetDto GetById(int id);
        List<AnswerGetDto> GetAll(int id);
        void Delete(int id);
        AnswerCreateDto Create(int questionId, AnswerCreateDto model);
        AnswerGetDto Update(int questionId, int id, AnswerCreateDto model);

    }
}
