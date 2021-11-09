using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.AnswerModels.Dtos
{
    public class AnswerGetDto
    {
        public int AnswerId { get; set; }
        public int Position { get; set; }
        public string AnswerText { get; set; }
        public bool IsDefault { get; set; }
    }
}
