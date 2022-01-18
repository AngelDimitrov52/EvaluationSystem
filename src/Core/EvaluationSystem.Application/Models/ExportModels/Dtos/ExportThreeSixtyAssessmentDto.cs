using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.ExportModels.Dtos
{
    public class ExportThreeSixtyAssessmentDto
    {
        public List<string> Labels { get; set; }
        public List<double> Supervisors { get; set; }
        public List<double> Peers { get; set; }
        public List<double> Subordinates { get; set; }
    }
}
