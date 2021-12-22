using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.QuestionModels.Intefaces
{
    public interface IQuestionRepository : IGenericRepository<QuestionTemplate>
    {
        List<QuestionRepositoryDto> GetAllQuestionTemplates();
        List<ModuleQuestionTemplateDto> GetModuleQuestions(int moduleId);
        void AddQuestionToModule(int moduleId, int questionId, int position);
        void DeleteQuestionFromModule(int questionId);
        void UpdateQuestionPosition(int moduleId, int questionId, int position);
        QuestionTemplate GetQuestionTemplateByNameAndId(string name, int questoinId);
        QuestionTemplate GetQuestionCustomByNameModuleIdAndQuestionId(string name, int moduleId, int questoinId);
    }
}
