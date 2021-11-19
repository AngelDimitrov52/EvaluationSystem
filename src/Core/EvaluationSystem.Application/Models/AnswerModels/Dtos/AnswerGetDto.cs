namespace EvaluationSystem.Application.Models.AnswerModels.Dtos
{
    public class AnswerGetDto
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public string AnswerText { get; set; }
        public bool IsDefault { get; set; }
    }
}
