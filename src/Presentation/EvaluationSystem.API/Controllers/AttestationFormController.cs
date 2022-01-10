using EvaluationSystem.Application.Models.AttestationFormModels.Interface;
using EvaluationSystem.Application.Models.AttestationQuestionModels.Dtos;
using EvaluationSystem.Application.Models.AttestationQuestionModels.Interface;
using EvaluationSystem.Application.Models.FormModels.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationSystem.API.Controllers
{
    [Route("api/attestationForm")]
    [ApiController]
    public class AttestationFormController : BaseController
    {
        private readonly IAttestationFormService _attestationFormService;
        private readonly IAttestationQuestionService _attestationQuestionService;
        public AttestationFormController(IAttestationFormService attestationFormService, IAttestationQuestionService attestationQuestionService)
        {
            _attestationFormService = attestationFormService;
            _attestationQuestionService = attestationQuestionService;
        }

        [HttpGet("{formId}")]
        public FormGetDto GetById(int formId)
        {
            return _attestationFormService.GetById(formId);
        }

        [HttpPut("{formId}")]
        public IActionResult Update(int formId, [FromBody] AttestationQuestionUpdateDto model)
        {
             _attestationQuestionService.Update(model);
            return Ok("Update successfully!");
        }
    }
}
