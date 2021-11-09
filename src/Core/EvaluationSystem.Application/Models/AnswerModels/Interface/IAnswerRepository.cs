

using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.AnswerModels
{
    public interface IAnswerRepository
    {
        Аnswer GetById(int id);
        List<Аnswer> GetAll(int questionId);
        void Delete(int id);
        int AddNew(AnswerCreateDbDto model);
        void Update(Аnswer model);
        void DeleteWithQuestionId(int IdQuestion);
    }
}
