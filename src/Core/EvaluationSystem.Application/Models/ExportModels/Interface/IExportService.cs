using EvaluationSystem.Application.Models.ExportModels.Dtos;

namespace EvaluationSystem.Application.Models.ExportModels.Interface
{
    public interface IExportService
    {
        ExportSelfAssessmentDto GetExportForSelfAssesmentForm(int attestationId);
        ExportThreeSixtyAssessmentDto GetExportForThreeSixtyForm(int attestationId);
    }
}
