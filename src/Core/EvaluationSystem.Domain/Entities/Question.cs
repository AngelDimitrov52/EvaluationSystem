using EvaluationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Domain.Entities
{
    public class Question : BaseEntity
    {
        public string Title { get; set; }
        public AnswersTypes Type { get; set; }
        public List<Аnswer> Answers { get; set; }

    }
}
