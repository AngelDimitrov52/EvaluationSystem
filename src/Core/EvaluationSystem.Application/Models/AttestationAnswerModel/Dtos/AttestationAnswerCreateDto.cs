namespace EvaluationSystem.Application.Models.AttestationAnswerModel.Dtos
{
    public class AttestationAnswerCreateDto
    {
        public int IdAttestation { get; set; }
        public int IdUserParticipant { get; set; }
        public int IdModule { get; set; }
        public int IdQuestion { get; set; }
        public int IdAnswer { get; set; }
        public string TextAnswer { get; set; }
    }
}
