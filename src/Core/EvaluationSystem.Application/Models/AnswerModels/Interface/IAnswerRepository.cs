using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AnswerModels
{
    public interface IAnswerRepository : IGenericRepository<AnswerTemplate>
    {
        List<AnswerTemplate> GetAllByQuestionId(int questionId);
        void DeleteWithQuestionId(int IdQuestion);
    }
}
