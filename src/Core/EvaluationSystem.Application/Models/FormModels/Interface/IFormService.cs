using EvaluationSystem.Application.Models.FormModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.FormModels.Interface
{
    public interface IFormService
    {
        List<FormGetDto> GetAll();
        FormGetDto GetById(int id);
        void Delete(int id);
        FormGetDto Create(FormCreateDto model);
        FormGetDto Update(int id, FormCreateDto model);
    }
}
