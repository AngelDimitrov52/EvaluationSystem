using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationSystem.API.Controllers
{
    [Route("api/question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService service)
        {
            _questionService = service;
        }

        [HttpGet]
        public List<QuestionGetDto> GetAll()
        {
            return _questionService.GetAll();
        }

        [HttpGet("{id}")]
        public QuestionGetDto GetById(int id)
        {
            return _questionService.GetById(id);
        }

        [HttpPost]
        public QuestionGetDto Create([FromBody] QuestionCreateDto model)
        {
            return _questionService.Create(model);
        }

        [HttpPut("{id}")]
        public QuestionUpdateDto Update(int id, [FromBody] QuestionUpdateDto model)
        {
            return _questionService.Update(id, model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _questionService.Delete(id);
            return NoContent();
        }
    }
}
