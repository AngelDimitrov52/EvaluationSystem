using EvaluationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Domain.Entities
{
    public class QuestionTemplate
    {
        [Key]
        public int QuestionId { get; set; }
        public string Name { get; set; }
        public bool IsReusable { get; set; }
        public AnswersTypes Type { get; set; }
        public List<AnswerTemplate> Answers { get; set; }

    }
}
