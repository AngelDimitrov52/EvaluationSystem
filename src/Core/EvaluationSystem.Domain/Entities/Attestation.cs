using System;

namespace EvaluationSystem.Domain.Entities
{
    public class Attestation : BaseEntity
    {
        public int IdAttestationForm { get; set; }
        public int IdUserToEval { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
