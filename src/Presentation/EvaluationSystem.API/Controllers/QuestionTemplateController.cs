using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvaluationSystem.API.Controllers
{
    [Route("api/questionTemplate")]
    [ApiController]
    public class QuestionTemplateController : BaseAdminController
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
        public QuestionTemplateGetDto Create([FromBody] QuestionTemplateCreateDto model)
        {
            return _questionTemplateService.Create(model);
        }

        [HttpPut("{questionId}")]
        public QuestionTemplateUpdateDto Update(int questionId, [FromBody] QuestionTemplateUpdateDto model)
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
