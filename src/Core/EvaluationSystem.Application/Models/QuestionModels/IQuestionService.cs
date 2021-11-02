using EvaluationSystem.Application.Models.Dtos;
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
        QuestionDto GetById(int id);
        QuestionDto Delete(int id);
        QuestionDto Create(QuestionDto model);
        QuestionDto Update(QuestionDto model);
    }
}
