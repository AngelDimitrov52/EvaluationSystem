using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.FormModels.Dtos
{
    public class FormWithModulesAndQuestionsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ModuleWithQuestionsDto> Modules { get; set; }
    }
}
