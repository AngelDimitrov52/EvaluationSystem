

using EvaluationSystem.Domain.Enums;

namespace EvaluationSystem.Application.Models.AnswerModels
{
   public class AnswerDto
    {
        public int Id { get; set; }
        public int IdQuestion { get; set; }
        public string AnswerText { get; set; }
    }
}
