using EvaluationSystem.Domain.Enums;

namespace EvaluationSystem.Application.Models.QuestionModels
{
    public class QuestionRepositoryDto
    {
        public int QuestionId { get; set; }
        public string Name { get; set; }
        public AnswersTypes Type { get; set; }
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public int Position { get; set; }
        public bool IsDefault { get; set; }
    }
}
