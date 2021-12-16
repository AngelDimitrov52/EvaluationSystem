namespace EvaluationSystem.Domain.Entities.AttestationEntities
{
    public class AttestationAnswer : BaseEntity
    {
        public int IdQuestion { get; set; }
        public string AnswerText { get; set; }
        public int Position { get; set; }
        public bool IsDefault { get; set; }
    }
}
