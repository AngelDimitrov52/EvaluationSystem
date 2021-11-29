using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Application.Models.QuestionModels.Intefaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvaluationSystem.API.Controllers
{
    [Route("api/questionTemplate")]
    [ApiController]
    public class QuestionTemplateController : ControllerBase
    {
        private readonly IQuestionTemplateService _questionTemplateService;

        public QuestionTemplateController(IQuestionTemplateService service)
        {
            _questionTemplateService = service;
        }

        [HttpGet]
        public List<QuestionTemplateGetDto> GetAll()
        {
            return _questionTemplateService.GetAll();
        }

        [HttpGet("{questionId}")]
        public QuestionTemplateGetDto GetById(int questionId)
        {
            return _questionTemplateService.GetById(questionId);
        }

        [HttpPost]
        public QuestionGetDto Create([FromBody] QuestionCreateDto model)
        {
            return _questionTemplateService.Create(model);
        }

        [HttpPut("{questionId}")]
        public QuestionUpdateDto Update(int questionId, [FromBody] QuestionUpdateDto model)
        {
            return _questionTemplateService.Update(questionId, model);
        }

        [HttpDelete("{questionId}")]
        public IActionResult Delete(int questionId)
        {
            _questionTemplateService.Delete(questionId);
            return NoContent();
        }
    }
}
