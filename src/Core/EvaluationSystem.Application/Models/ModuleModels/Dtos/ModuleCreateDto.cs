using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.ModuleModels.Dtos
{
    public class ModuleCreateDto
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public string Description { get; set; }
        public List<QuestionCreateDto> Questions { get; set; }
    }
}
