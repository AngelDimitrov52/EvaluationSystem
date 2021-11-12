

using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.AnswerModels
{
    public interface IAnswerRepository : IGenericRepository<AnswerTemplate>
    {
        
        List<AnswerTemplate> GetAllByQuestionId(int questionId);
        int AddNew(AnswerCreateDbDto model);
        void Update(AnswerTemplate model);
        void DeleteWithQuestionId(int IdQuestion);
    }
}
