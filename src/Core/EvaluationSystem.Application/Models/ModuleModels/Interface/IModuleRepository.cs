using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.ModuleModels.Interface
{
    public interface IModuleRepository : IGenericRepository<ModuleTemplate>
    {
        void AddQuestionToModule(int moduleId, int questionId, int position);
        void DeleteQuestionFromModule(int moduleId, int questionId);
        List<ModuleQuestionTemplateDto> GetModuleQuestions(int moduleId);
        void DeleteModuleFromFormModuleTable(int moduleId);
        void EditQuestionPosition(int moduleId, int questionId, int position);
    }
}
