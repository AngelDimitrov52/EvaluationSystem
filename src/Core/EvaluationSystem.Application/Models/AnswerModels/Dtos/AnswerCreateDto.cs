namespace EvaluationSystem.Application.Models.AnswerModels.Dtos
{
    public class AnswerCreateDto
    {
        public string AnswerText { get; set; }
        public int Position { get; set; }
        public bool IsDefault { get; set; }
    }
}
