using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using EvaluationSystem.Domain.Entities.AttestationEntities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AttestationAnswerModels.Interface
{
    public interface IAttestationAnswerRepository : IGenericRepository<AttestationAnswer>
    {
        List<AttestationAnswer> GetAllByQuestionId(int questionId);
        void DeleteWithQuestionId(int idQuestion);
    }
}
