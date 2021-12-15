using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Domain.Enums;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.QuestionModels.Dtos
{
    public class QuestionAttestationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public AnswersTypes Type { get; set; }
        public List<AnswerAttestationGetDto> Answers { get; set; }
        public string TextAnswer { get; set; } = null;
    }
}
