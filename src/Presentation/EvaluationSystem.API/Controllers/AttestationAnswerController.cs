﻿using EvaluationSystem.Application.Models.AttestationAnswerModel.Dtos;
using EvaluationSystem.Application.Models.AttestationAnswerModel.Interface;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create(AttestationAnswerCreateDto attestationAnswerCreateDtos)
        {
            _attestationAnswerService.Create(attestationAnswerCreateDtos);
            return NoContent();
        }
    }
}
