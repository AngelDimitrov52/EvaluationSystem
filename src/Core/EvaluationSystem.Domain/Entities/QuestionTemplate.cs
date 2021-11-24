using EvaluationSystem.Domain.Enums;
using System.Collections.Generic;

namespace EvaluationSystem.Domain.Entities
{
    public class QuestionTemplate : BaseEntity
    {
        public string Name { get; set; }
        public bool IsReusable { get; set; }
        public AnswersTypes Type { get; set; }
        public List<AnswerTemplate> Answers { get; set; }
    }
}
