using EvaluationSystem.Application.Models.AttestationModels.Dtos;
using EvaluationSystem.Application.Models.AttestationModels.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvaluationSystem.API.Controllers
{
    [Route("api/attestation")]
    [ApiController]
    public class AttestationController : BaseController
    {
        private readonly IAttestationService _attestationService;
        public AttestationController(IAttestationService attestationService)
        {
            _attestationService = attestationService;
        }
        [HttpGet]
        public List<AttestationGetDto> GetAll()
        {
            return _attestationService.GetAll();
        }
        [HttpPost]
        public AttestationGetDto Create(int userId, int formId, [FromBody] List<int> participantsIds)
        {
            return _attestationService.Create(userId, formId, participantsIds);
        }

        [HttpDelete("{attestationId}")]
        public IActionResult Delete(int attestationId)
        {
            _attestationService.Delete(attestationId);
            return NoContent();
        }
    }
}
