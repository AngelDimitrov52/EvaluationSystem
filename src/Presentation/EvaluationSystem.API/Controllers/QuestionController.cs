using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Application.Models.QuestionModels.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationSystem.API.Controllers
{
    [Route("api/form/{formId}/module/{moduleId}/question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService service)
        {
            _questionService = service;
        }

        [HttpGet]
        public List<QuestionGetDto> GetAll(int formId, int moduleId)
        {
            return _questionService.GetAll(moduleId);
        }

        [HttpGet("{questioId}")]
        public QuestionGetDto GetById(int formId, int moduleId, int questioId)
        {
            return _questionService.GetById(moduleId, questioId);
        }

        [HttpPost]
        public QuestionGetDto Create(int formId, int moduleId, [FromBody] QuestionCreateDto model)
        {
            return _questionService.Create(moduleId, model);
        }

        [HttpPut("{questioId}")]
        public QuestionUpdateDto Update(int formId, int moduleId, int questioId, [FromBody] QuestionUpdateDto model)
        {
            return _questionService.Update(questioId, model);
        }

        [HttpDelete("{questioId}")]
        public IActionResult Delete(int formId, int moduleId, int questioId)
        {
            _questionService.Delete(questioId);
            return NoContent();
        }
    }
}
