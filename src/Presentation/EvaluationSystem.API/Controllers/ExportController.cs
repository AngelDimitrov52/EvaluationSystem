using EvaluationSystem.Application.Models.ExportModels.Dtos;
using EvaluationSystem.Application.Models.ExportModels.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationSystem.API.Controllers
{
    [Route("api/export")]
    [ApiController]
    public class ExportController : BaseAdminController
    {
        private readonly IExportService _exportService;
        public ExportController(IExportService exportService)
        {
            _exportService = exportService;
        }

        [HttpGet("Self-Assessment/{attestationId}")]
        public ExportSelfAssessmentDto GetAll(int attestationId)
        {
            return _exportService.GetExportForSelfAssesmentForm(attestationId);
        }
    }
}
