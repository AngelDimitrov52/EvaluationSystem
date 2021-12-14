using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Domain.Enums;
using System;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.QuestionModels.Dtos
{
    public class QuestionTemplateGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AnswersTypes Type { get; set; }
        public DateTime DateOfCreation { get; set; }
        public List<AnswerGetDto> Answers { get; set; }
    }
}
