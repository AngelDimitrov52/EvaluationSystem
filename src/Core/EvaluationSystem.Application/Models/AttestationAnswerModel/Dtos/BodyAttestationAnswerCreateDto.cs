using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.AttestationAnswerModel.Dtos
{
    public class BodyAttestationAnswerCreateDto
    {
        public int ModuleId { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }
        public List<int> AnswerIds { get; set; }
    }
}
