
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AnswerModels
{
   public interface IAnswerService
    {
         AnswerDto GetById(int id);
        List<AnswerDto> GetAll();
        AnswerDto Delete(int id);
        AnswerDto Create(AnswerDto model);
        AnswerDto Update(AnswerDto model);

    }
}
