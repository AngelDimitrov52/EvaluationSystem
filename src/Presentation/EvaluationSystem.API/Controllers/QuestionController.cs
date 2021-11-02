using EvaluationSystem.Application.Models.Dtos;
using EvaluationSystem.Application.Models.QuestionModels;
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
    public class QuestionController : ControllerBase
    {
        private IQuestionService questionService;
        public QuestionController(IQuestionService service)
        {
            questionService = service;
        }

        [HttpGet]
        public List<QuestionDto> GetAllQuestions()
        {
            List<QuestionDto> result = questionService.GetAll();
            return result;
        }

        [HttpGet("{id}")]
        public QuestionDto GetQuestionsById(int id)
        {
            QuestionDto result = questionService.GetById(id);
            return result;
        }

        [HttpPost]
        public QuestionDto CreateQuestion([FromBody] QuestionDto model)
        {
            QuestionDto result = questionService.Create(model);
            return result;
        }

        [HttpPut]
        public QuestionDto UpdateQuestion([FromBody] QuestionDto model)
        {
            QuestionDto result = questionService.Update(model);
            return result;
        }

        [HttpDelete("{id}")]
        public QuestionDto DeleteQuestion(int id)
        {
            QuestionDto result = questionService.Delete(id);
            return result;
        }
    }
}
