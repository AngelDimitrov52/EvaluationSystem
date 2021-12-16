using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AttestationAnswerModels.Interface
{
    public interface IAttestationAnswerService
    {
        void Create(int questionId, AnswerCreateDto model);
        List<AnswerGetDto> GetAll(int questionId);
    }
}
