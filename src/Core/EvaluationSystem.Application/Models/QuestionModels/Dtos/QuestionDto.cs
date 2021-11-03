using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AnswersTypes Type { get; set; }
        public List<AnswerGetDto> Answers { get; set; }
    }
}
