using System;

namespace EvaluationSystem.Domain.Entities
{
    public class Attestation : BaseEntity
    {
        public int IdFormTemplate { get; set; }
        public int IdUserToEval { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
