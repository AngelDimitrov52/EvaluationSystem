using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Domain.Entities
{
   public class QuestionEntity : BaseEntity
    {
        public int ModuleId { get; set; }
        public string Title { get; set; }
        public List<АnswerEntity> Answers { get; set; }

    }
}
