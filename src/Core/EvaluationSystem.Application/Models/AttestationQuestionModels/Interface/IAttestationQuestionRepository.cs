using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Domain.Entities.AttestationEntities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AttestationQuestionModels.Interface
{
    public interface IAttestationQuestionRepository : IGenericRepository<AttestationQuestion>
    {
        void AddAttestationQuestionToAttestationModule(int moduleId, int questionId, int position);
        List<ModuleQuestionTemplateDto> GetModuleQuestions(int moduleId);
        void DeleteQuestionFromModule(int questionId);
    }
}
