
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Application.Services.AnswerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationSystem.API.Controllers
{
    [Route("api/question/{questionId}/answers")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService answerService;
        public AnswerController(IAnswerService service)
        {
            answerService = service;
        }

        [HttpGet]
        public List<AnswerGetDto> GetAllAnswer(int questionId)
        {
            return answerService.GetAll(questionId);
        }

        [HttpGet("{answerId}")]
        public AnswerGetDto GetAnswerById(int questionId, int answerId)
        {
            return answerService.GetById(answerId);
        }

        [HttpPost]
        public AnswerCreateDto CreateAnswer(int questionId, [FromBody] AnswerCreateDto model)
        {
            return answerService.Create(questionId, model);
        }

        [HttpPut("{answerId}")]
        public AnswerGetDto UpdateAnswer(int questionId, int answerId, [FromBody] AnswerCreateDto model)
        {
            return answerService.Update(questionId, answerId, model);
        }

        [HttpDelete("{answerId}")]
        public IActionResult DeleteAnswer(int questionId, int answerId)
        {
            answerService.Delete(answerId);
            return NoContent();
        }
    }
}
