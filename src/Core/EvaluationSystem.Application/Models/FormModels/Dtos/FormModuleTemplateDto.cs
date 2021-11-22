using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.FormModels.Dtos
{
    public class FormModuleTemplateDto
    {
        public int Id { get; set; }
        public int IdForm { get; set; }
        public int IdModule { get; set; }
        public int Position { get; set; }
    }
}
