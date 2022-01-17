using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.ExportModels.Dtos
{
    public class ExportSelfAssessmentDto
    {
        public List<string> Labels { get; set; }
        public List<int> UserResult { get; set; }
        public List<double> ParticipantResult { get; set; }
    }
}
