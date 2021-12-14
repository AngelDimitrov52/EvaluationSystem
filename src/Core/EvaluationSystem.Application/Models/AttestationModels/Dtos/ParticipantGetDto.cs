using EvaluationSystem.Domain.Enums;

namespace EvaluationSystem.Application.Models.AttestationModels.Dtos
{
    public class ParticipantGetDto
    {
        public string Name { get; set; }
        public AttestationStatus ParticipantStatus { get; set; }
    }
}
