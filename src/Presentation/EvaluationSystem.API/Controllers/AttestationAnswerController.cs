using EvaluationSystem.Application.Models.AttestationAnswerModel.Dtos;
using EvaluationSystem.Application.Models.AttestationAnswerModel.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationSystem.API.Controllers
{
    [Route("api/attestationAnswer")]
    [ApiController]
    public class AttestationAnswerController : BaseController
    {
        private readonly IAttestationAnswerService _attestationAnswerService;
        public AttestationAnswerController(IAttestationAnswerService attestationAnswerService)
        {
            _attestationAnswerService = attestationAnswerService;
        }

        [HttpPost]
        public IActionResult Create(List<AttestationAnswerCreateDto> attestationAnswerCreateDtos)
        {
            _attestationAnswerService.Create(attestationAnswerCreateDtos);
            return NoContent();
        }
    }
}
