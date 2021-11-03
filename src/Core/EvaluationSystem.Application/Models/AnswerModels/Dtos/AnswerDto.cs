

using EvaluationSystem.Domain.Enums;

namespace EvaluationSystem.Application.Models.AnswerModels
{
   public class AnswerDto
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Title { get; set; }
    }
}
