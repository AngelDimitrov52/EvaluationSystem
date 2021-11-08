using EvaluationSystem.Application.Models.Dtos;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.QuestionModels
{
    public interface IQuestionService
    {
        List<QuestionDto> GetAll();
        QuestionGetDto GetById(int id);
        void Delete(int id);
        QuestionCreateDto Create(QuestionCreateDto model);
        QuestionUpdateDto Update(int id, QuestionUpdateDto model);
    }
}
