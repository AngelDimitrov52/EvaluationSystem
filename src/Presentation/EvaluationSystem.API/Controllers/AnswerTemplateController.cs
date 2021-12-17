using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvaluationSystem.API.Controllers
{
    [Route("api/questionTemplate/{questionId}/answersTemplate")]
    [ApiController]
    public class AnswerTemplateController : BaseController
    {
        private readonly IAnswerService _answerService;
        public AnswerTemplateController(IAnswerService service)
        {
            _answerService = service;
        }

        [HttpGet]
        public List<AnswerGetDto> GetAll(int questionId)
        {
            return _answerService.GetAll(questionId);
        }

        [HttpGet("{answerTemplateId}")]
        public AnswerGetDto GetById(int answerTemplateId)
        {
            return _answerService.GetById(answerTemplateId);
        }

        [HttpPost]
        public AnswerGetDto Create(int questionId, [FromBody] AnswerCreateDto model)
        {
            return _answerService.Create(questionId, model);
        }

        [HttpPut("{answerTemplateId}")]
        public AnswerGetDto Update(int questionId, int answerTemplateId, [FromBody] AnswerCreateDto model)
        {
            return _answerService.Update(questionId, answerTemplateId, model);
        }

        [HttpDelete("{answerTemplateId}")]
        public IActionResult Delete(int answerTemplateId)
        {
            _answerService.Delete(answerTemplateId);
            return NoContent();
        }
    }
}
