using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.QuestionModels
{
    public interface IQuestionRepository : IGenericRepository<QuestionTemplate>
    {
        List<QuestionRepositoryDto> GetQuestionById(int id);
        List<QuestionRepositoryDto> GetAllQuestions();
        void DeleteQuestionFromModuleQuestionTable(int questionId);
    }
}
