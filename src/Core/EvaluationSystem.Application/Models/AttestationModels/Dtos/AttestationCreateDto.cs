using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.AttestationModels.Dtos
{
    public class AttestationCreateDto
    {
        public int UserId { get; set; }
        public int FormId { get; set; }
        public List<int> ParticipantsIds { get; set; }
    }
}
