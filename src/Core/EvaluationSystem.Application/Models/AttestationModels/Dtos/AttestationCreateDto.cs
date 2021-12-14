using EvaluationSystem.Application.Models.UserModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.AttestationModels.Dtos
{
    public class AttestationCreateDto
    {
        public UserCreateDto User { get; set; }
        public int FormId { get; set; }
        public List<UserEvaluatorCreateDto> Participants { get; set; }
    }
}
