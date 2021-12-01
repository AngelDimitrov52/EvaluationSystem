using EvaluationSystem.Application.Models.FormModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.FormModels.Interface
{
    public interface IFormService
    {
        List<FormGetDto> GetAll();
        FormGetDto GetById(int formId);
        FormGetDto Create(FormCreateDto model);
        FormUpdateDto Update(int formId, FormUpdateDto model);
        void Delete(int formId);
    }
}
