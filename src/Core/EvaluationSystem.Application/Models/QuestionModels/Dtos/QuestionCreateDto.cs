using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.QuestionModels.Dtos
{
    public class QuestionCreateDto
    {
        public string Title { get; set; }
        public AnswersTypes Type { get; set; }
        public List<AnswerCreateDto> Answers { get; set; }
    }
}
