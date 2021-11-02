

using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AnswerModels
{
    public interface IAnswerRepository
    {
        Аnswer GetById(int id);
        List<Аnswer> GetAllAnswerByQuestionId(int id);
        List<Аnswer> GetAll();
        Аnswer Delete(int id);
        Аnswer AddNew(Аnswer model);
        Аnswer Update(Аnswer model);
    }
}
