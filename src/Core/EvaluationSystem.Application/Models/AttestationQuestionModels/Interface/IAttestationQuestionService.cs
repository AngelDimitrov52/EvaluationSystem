using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AttestationQuestionModels.Interface
{
    public interface IAttestationQuestionService
    {
        void Create(int moduleId, QuestionCreateDto model);
        List<QuestionGetDto> GetAll(int moduleId);
        void Delete(int questionId);
    }
}
