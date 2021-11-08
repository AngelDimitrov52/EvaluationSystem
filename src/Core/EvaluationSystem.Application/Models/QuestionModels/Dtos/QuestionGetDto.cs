using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.QuestionModels.Dtos
{
    public class QuestionGetDto
    {
        public string Name { get; set; }
        public AnswersTypes Type { get; set; }
        public bool IsReusable { get; set; }
        public List<AnswerGetDto> Answers { get; set; }
    }
}
