

using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.AnswerModels
{
    public interface IAnswerRepository
    {
        Аnswer GetById(int id);
        List<Аnswer> GetAllAnswerByQuestionId(int id);
        List<Аnswer> GetAll();
        void Delete(int id);
        void AddNew(AnswerCreateDbDto model);
        void Update(Аnswer model);
    }
}
