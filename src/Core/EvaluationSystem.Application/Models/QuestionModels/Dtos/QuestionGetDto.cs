using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Domain.Enums;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.QuestionModels.Dtos
{
    public class QuestionGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AnswersTypes Type { get; set; }
        public bool IsReusable { get; set; }
        public List<AnswerGetDto> Answers { get; set; }
    }
}
