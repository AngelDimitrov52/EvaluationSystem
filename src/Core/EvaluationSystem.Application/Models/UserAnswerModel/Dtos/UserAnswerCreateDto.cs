using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AttestationAnswerModel.Dtos
{
    public class UserAnswerCreateDto
    {
        public int AttestationId { get; set; }
        public List<BodyUserAnswerCreateDto> Body { get; set; }
    }
}
