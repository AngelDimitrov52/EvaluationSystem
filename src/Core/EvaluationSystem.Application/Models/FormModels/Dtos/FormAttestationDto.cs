using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.FormModels.Dtos
{
    public class FormAttestationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ModuleAttestationDto> Modules { get; set; }
    }
}
