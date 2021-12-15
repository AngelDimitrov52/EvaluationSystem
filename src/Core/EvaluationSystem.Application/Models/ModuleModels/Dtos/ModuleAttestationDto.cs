using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.ModuleModels.Dtos
{
    public class ModuleAttestationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public List<QuestionAttestationDto> Questions { get; set; }
    }
}
