using EvaluationSystem.Application.Models.AttestationAnswerModel.Dtos;
using EvaluationSystem.Application.Models.AttestationAnswerModel.Interface;
using EvaluationSystem.Application.Models.FormModels.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationSystem.API.Controllers
{
    [Route("api/userAnswer")]
    [ApiController]
    public class UserAnswerController : BaseController
    {
        private readonly IUserAnswerService _attestationAnswerService;
        public UserAnswerController(IUserAnswerService attestationAnswerService)
        {
            _attestationAnswerService = attestationAnswerService;
        }
        [HttpGet("attestationId/{attestationId}/participantEmail/{participantEmail}")]
        public FormAttestationDto GetAll(int attestationId, string participantEmail)
        {
            return _attestationAnswerService.GetFormWhithCurrentAnswers(attestationId, participantEmail);
        }

        [HttpPost]
        public IActionResult Create(UserAnswerCreateDto attestationAnswerCreateDtos)
        {
            _attestationAnswerService.Create(attestationAnswerCreateDtos);
            return NoContent();
        }
    }
}
