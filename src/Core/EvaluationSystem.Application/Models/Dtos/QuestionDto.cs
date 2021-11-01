using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.Dtos
{
    public class QuestionDto : BaseDto
    {
        public int ModuleId { get; set; }
        public string Title { get; set; }
        public List<АnswerEntity> Answers { get; set; }
    }
}
