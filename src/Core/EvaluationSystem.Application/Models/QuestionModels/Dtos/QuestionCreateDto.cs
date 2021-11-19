using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Domain.Enums;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.QuestionModels.Dtos
{
    public class QuestionCreateDto
    {
        public string Name { get; set; }
        public bool IsReusable { get; set; }
        public AnswersTypes Type { get; set; }
        public List<AnswerCreateDto> Answers { get; set; }
    }
}
