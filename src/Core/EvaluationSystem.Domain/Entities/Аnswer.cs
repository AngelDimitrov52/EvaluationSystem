using EvaluationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Domain.Entities
{
    public class Аnswer : BaseEntity
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }
}
