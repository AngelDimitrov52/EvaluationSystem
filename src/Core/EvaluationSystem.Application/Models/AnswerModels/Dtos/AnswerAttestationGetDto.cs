namespace EvaluationSystem.Application.Models.AnswerModels.Dtos
{
    public class AnswerAttestationGetDto
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public string AnswerText { get; set; }
        public bool IsAnswered { get; set; } = false;
    }
}
