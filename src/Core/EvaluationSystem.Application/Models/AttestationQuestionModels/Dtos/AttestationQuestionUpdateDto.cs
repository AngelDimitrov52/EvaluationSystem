using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AttestationQuestionModels.Dtos
{
    public class AttestationQuestionUpdateDto
    {
        public int attestationQuestionId { get; set; }
        public List<int> AnswerIds { get; set; }
        public string AnswerText { get; set; }
    }
}
