using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.ModuleModels.Dtos
{
   public class ModuleWithQuestionsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<QuestionGetDto> Questions { get; set; }
    }
}
