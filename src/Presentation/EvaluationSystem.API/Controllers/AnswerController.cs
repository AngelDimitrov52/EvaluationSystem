
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Services.AnswerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private IAnswerService answerService;
        public AnswerController(IAnswerService service)
        {
            answerService = service;
        }
        [HttpGet("{id}")]
        public AnswerDto GetAnswerById(int id)
        {
            AnswerDto result = answerService.GetById(id);

            return result;
        }
    }
}
