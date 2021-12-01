using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.QuestionModels.Intefaces
{
    public interface IQuestionRepository : IGenericRepository<QuestionTemplate>
    {
        List<QuestionRepositoryDto> GetAllQuestionTemplates();
        List<QuestionRepositoryDto> GetQuestionById(int questionId);
        List<ModuleQuestionTemplateDto> GetModuleQuestions(int moduleId);
        void AddQuestionToModule(int moduleId, int questionId, int position);
        void DeleteQuestionFromModule(int questionId);
        void UpdateQuestionPosition(int moduleId, int questionId, int position);
    }
}
