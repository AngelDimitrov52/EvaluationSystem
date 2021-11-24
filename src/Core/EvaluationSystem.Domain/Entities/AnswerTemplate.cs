namespace EvaluationSystem.Domain.Entities
{
    public class AnswerTemplate : BaseEntity
    {
        public int IdQuestion { get; set; }
        public string AnswerText { get; set; }
        public int Position { get; set; }
        public bool IsDefault { get; set; }
    }
}
