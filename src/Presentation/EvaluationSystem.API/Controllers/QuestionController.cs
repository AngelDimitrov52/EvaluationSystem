using EvaluationSystem.Application.Models.Dtos;
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
        private readonly IQuestionService questionService;
        public QuestionController(IQuestionService service)
        {
            questionService = service;
        }

        [HttpGet]
        public List<QuestionDto> GetAllQuestions()
        {
            return questionService.GetAll();
        }

        [HttpGet("{id}")]
        public QuestionGetDto GetQuestionsById(int id)
        {
            return questionService.GetById(id);
        }

        [HttpPost]
        public QuestionDto CreateQuestion([FromBody] QuestionCreateDto model)
        {
            return questionService.Create(model);
        }

        [HttpPut("{id}")]
        public QuestionUpdateDto UpdateQuestion(int id, [FromBody] QuestionUpdateDto model)
        {
            return questionService.Update(id, model);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(int id)
        {
            questionService.Delete(id);
            return NoContent();
        }
    }
}
