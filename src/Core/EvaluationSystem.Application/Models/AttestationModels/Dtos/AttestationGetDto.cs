using System;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AttestationModels.Dtos
{
    public class AttestationGetDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FormName { get; set; }
        public string Status { get; set; }
        public DateTime DateOfCreation { get; set; }
        public List<ParticipantGetDto> Participants { get; set; }
    }
}
