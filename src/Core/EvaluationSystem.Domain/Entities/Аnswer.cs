using EvaluationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Domain.Entities
{
    public class Аnswer 
    {
        public int AnswerId { get; set; }
        public int IdQuestion { get; set; }
        public string AnswerText { get; set; }
        public int Position { get; set; }
        public bool IsDefault { get; set; }
    }
}
