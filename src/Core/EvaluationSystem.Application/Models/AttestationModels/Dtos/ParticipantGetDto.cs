using EvaluationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.AttestationModels.Dtos
{
   public class ParticipantGetDto
    {
        public string Name { get; set; }
        public AttestationStatus ParticipantStatus { get; set; }
    }
}
