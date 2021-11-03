using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.QuestionModels
{
    public interface IQuestionRepository
    {
        Question GetById(int id);
        List<Question> GetAll();
        void Delete(int id);
        Question AddNew(Question model);
        Question Update(Question model);

    }
}
