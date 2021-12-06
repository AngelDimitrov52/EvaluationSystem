using Dapper;
using EvaluationSystem.Application.Models.FormModels.Interface;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Persistence.Repositories
{
    public class FormRepository : GenericRepository<FormTemplate>, IFormRepository
    {
        public FormRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public List<Attestation> GetAllAttestationsWithFormId(int formId)
        {
            string query = @"SELECT * FROM Attestation WHERE  IdFormTemplate = @IdForm";
            var result = Connection.Query<Attestation>(query, new { IdForm = formId }, Transaction);
            return (List<Attestation>)result;
        }
        public void DeleteFormFromFormModuleTable(int formId)
        {
            string query = @"Delete from FormModule where IdForm = @IdForm";
            Connection.Execute(query, new { IdForm = formId }, Transaction);
        }
    }
}
