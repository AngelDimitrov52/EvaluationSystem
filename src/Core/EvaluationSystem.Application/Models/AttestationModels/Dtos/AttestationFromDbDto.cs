using EvaluationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.AttestationModels.Dtos
{
    public class AttestationFromDbDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FormName { get; set; }
        public AttestationStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string ParticipantName { get; set; }
    }
}
