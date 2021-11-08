using EvaluationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.QuestionModels.Dtos
{
    public class QuestionDbCreateDto
    {
        public string Name { get; set; }
        public bool IsReusable { get; set; }
        public AnswersTypes Type { get; set; }
    }
}
