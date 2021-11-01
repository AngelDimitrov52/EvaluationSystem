

using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AnswerModels
{
   public interface IAnswerRepository
    {
         Аnswer GetAnswerById(int id);
        List<Аnswer> GetAllAnswerByQuestionId(int id);
    }
}
