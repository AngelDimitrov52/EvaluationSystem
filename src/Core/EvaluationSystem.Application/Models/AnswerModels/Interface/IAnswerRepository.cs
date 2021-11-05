

using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.AnswerModels
{
    public interface IAnswerRepository
    {
        Аnswer GetById(int questionId, int id);
        List<Аnswer> GetAllAnswerByQuestionId(int id);
        Task<List<Аnswer>> GetAll();
        void Delete(int id);
        void AddNew(Аnswer model);
        Аnswer Update(Аnswer model);
    }
}
