using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvaluationSystem.API.Controllers
{
    [Route("api/question/{questionId}/answers")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        public AnswerController(IAnswerService service)
        {
            _answerService = service;
        }

        [HttpGet]
        public List<AnswerGetDto> GetAll(int questionId)
        {
            return _answerService.GetAll(questionId);
        }

        [HttpGet("{answerId}")]
        public AnswerGetDto GetById(int questionId, int answerId)
        {
            return _answerService.GetById(answerId);
        }

        [HttpPost]
        public AnswerGetDto Create(int questionId, [FromBody] AnswerCreateDto model)
        {
            return _answerService.Create(questionId, model);
        }

        [HttpPut("{answerId}")]
        public AnswerGetDto Update(int questionId, int answerId, [FromBody] AnswerCreateDto model)
        {
            return _answerService.Update(questionId, answerId, model);
        }

        [HttpDelete("{answerId}")]
        public IActionResult Delete(int questionId, int answerId)
        {
            _answerService.Delete(answerId);
            return NoContent();
        }
    }
}
