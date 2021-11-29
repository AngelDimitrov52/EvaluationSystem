using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.FormModels.Dtos
{
    public class FormCreateDto
    {
        public string Name { get; set; }
        public List<ModuleCreateDto> Modules { get; set; }
    }
}
