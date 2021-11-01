

using EvaluationSystem.Domain.Enums;

namespace EvaluationSystem.Application.Models.AnswerModels
{
   public class AnswerDto : BaseDto
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }
}
