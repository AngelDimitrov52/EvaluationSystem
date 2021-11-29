using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.ModuleModels.Dtos
{
    public class ModuleGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public List<QuestionGetDto> Questions { get; set; }
    }
}
