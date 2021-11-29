using Dapper;
using EvaluationSystem.Application.Models.FormModels.Dtos;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Persistence.Repositories
{
    public class ModuleRepository : GenericRepository<ModuleTemplate>, IModuleRepository
    {
        public ModuleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public List<FormModuleTemplateDto> GetFormModulesByFormId(int formId)
        {
            string query = @"SELECT * FROM FormModule WHERE IdForm = @IdForm  ORDER BY [Position] ASC";
            var result = Connection.Query<FormModuleTemplateDto>(query, new { IdForm = formId }, Transaction);
            return (List<FormModuleTemplateDto>)result;
        }
        public void AddModuleToForm(int formId, int moduleId, int position)
        {
            string query = "Insert Into FormModule (IdForm, IdModule, Position) Values(@IdForm, @IdModule, @Position)";
            Connection.Execute(query, new { IdModule = moduleId, IdForm = formId, Position = position }, Transaction);
        }
        public void DeleteModuleFromFormModuleTable(int moduleId)
        {
            string query = @"Delete from FormModule where IdModule = @IdModule";
            Connection.Execute(query, new { IdModule = moduleId }, Transaction);
        }
        public void DeleteModuleFromModuleQuestionTable(int moduleId)
        {
            string query = "Delete from ModuleQuestion where IdModule = @IdModule";
            Connection.Execute(query, new { IdModule = moduleId }, Transaction);
        }
    }
}
