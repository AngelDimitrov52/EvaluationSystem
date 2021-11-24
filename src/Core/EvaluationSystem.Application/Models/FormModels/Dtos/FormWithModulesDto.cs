using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.FormModels.Dtos
{
    public class FormWithModulesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ModuleGetDto> Modules { get; set; }
    }
}
