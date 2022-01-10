namespace EvaluationSystem.Domain.Entities
{
    public class AttestationParticipant : BaseEntity
    {
        public int IdAttestation { get; set; }
        public int IdUserParticipant { get; set; }
        public string Status { get; set; }
        public string Position { get; set; }
        public int AttestationFormId { get; set; }
    }
}
