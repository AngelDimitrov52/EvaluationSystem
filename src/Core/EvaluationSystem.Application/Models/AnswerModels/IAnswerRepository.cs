

using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AnswerModels
{
   public interface IAnswerRepository
    {
         АnswerEntity GetAnswerById(int id);
        List<АnswerEntity> GetAllAnswerByQuestionId(int id);


    }
}
