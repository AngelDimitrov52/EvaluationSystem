using Dapper;
using EvaluationSystem.Application.Models.AttestationFormModels.Interface;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities.AttestationEntities;

namespace EvaluationSystem.Persistence.Repositories.AttestationRepositories
{
    public class AttestationFormRepository : GenericRepository<AttestationForm> , IAttestationFormRepository
    {
        public AttestationFormRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public void DeleteFormFromFormModuleTable(int formId)
        {
            string query = @"Delete from AttestationFormModule where IdForm = @IdForm";
            Connection.Execute(query, new { IdForm = formId }, Transaction);
        }

    }
}
