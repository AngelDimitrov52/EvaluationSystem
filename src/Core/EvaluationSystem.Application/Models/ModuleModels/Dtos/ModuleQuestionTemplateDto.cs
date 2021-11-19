using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.ModuleModels.Dtos
{
    public class ModuleQuestionTemplateDto
    {
        public int Id { get; set; }
        public int IdModule { get; set; }
        public int IdQuestion { get; set; }
        public int Position { get; set; }
    }
}
