namespace EvaluationSystem.Application.Models.AnswerModels.Dtos
{
    public class AnswerCreateDbDto
    {
        public int IdQuestion { get; set; }
        public string AnswerText { get; set; }
        public int Position { get; set; }
        public bool IsDefault { get; set; }
    }
}
