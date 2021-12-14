using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AttestationAnswerModel.Dtos
{
    public class AttestationAnswerCreateDto
    {
        public int AttestationId { get; set; }
        public List<BodyAttestationAnswerCreateDto> Body { get; set; }
    }
}
