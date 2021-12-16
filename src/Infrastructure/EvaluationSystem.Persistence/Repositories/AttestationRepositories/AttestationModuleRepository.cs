using Dapper;
using EvaluationSystem.Application.Models.AttestationModuleModels.Interface;
using EvaluationSystem.Application.Models.FormModels.Dtos;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities.AttestationEntities;
using System.Collections.Generic;

namespace EvaluationSystem.Persistence.Repositories.AttestationRepositories
{
    public class AttestationModuleRepository : GenericRepository<AttestationModule>, IAttestationModuleRepository
    {
        public AttestationModuleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void AddAttestationModuleToAttestatationForm(int formId, int moduleId, int position)
        {
            string query = "Insert Into AttestationFormModule (IdForm, IdModule, Position) Values(@IdForm, @IdModule, @Position)";
            Connection.Execute(query, new { IdModule = moduleId, IdForm = formId, Position = position }, Transaction);
        }
        public List<FormModuleTemplateDto> GetFormModulesByFormId(int formId)
        {
            string query = @"SELECT * FROM AttestationFormModule WHERE IdForm = @IdForm  ORDER BY [Position] ASC";
            var result = Connection.Query<FormModuleTemplateDto>(query, new { IdForm = formId }, Transaction);
            return (List<FormModuleTemplateDto>)result;
        }
        public void DeleteModuleFromFormModuleTable(int moduleId)
        {
            string query = @"Delete from AttestationFormModule where IdModule = @IdModule";
            Connection.Execute(query, new { IdModule = moduleId }, Transaction);
        }
        public void DeleteModuleFromModuleQuestionTable(int moduleId)
        {
            string query = "Delete from AttestationModuleQuestion where IdModule = @IdModule";
            Connection.Execute(query, new { IdModule = moduleId }, Transaction);
        }
    }
}
