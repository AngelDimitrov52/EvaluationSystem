using EvaluationSystem.Domain.Enums;
using System.Collections.Generic;

namespace EvaluationSystem.Domain.Entities.AttestationEntities
{
    public class AttestationQuestion : BaseEntity
    {
        public string Name { get; set; }
        public bool IsReusable { get; set; }
        public AnswersTypes Type { get; set; }
        public List<AttestationAnswer> Answers { get; set; }
        public string AnswerText { get; set; }
    }
}
