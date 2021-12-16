using EvaluationSystem.Application.Models.AttestationFormModels.Interface;
using EvaluationSystem.Application.Models.FormModels.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationSystem.API.Controllers
{
    [Route("api/attestationForm")]
    [ApiController]
    public class AttestationFormController : BaseController
    {
        private readonly IAttestationFormService _attestationFormService;
        public AttestationFormController(IAttestationFormService attestationFormService)
        {
            _attestationFormService = attestationFormService;
        }

        [HttpGet("{formId}")]
        public FormGetDto GetById(int formId)
        {
            return _attestationFormService.GetById(formId);
        }
    }
}
