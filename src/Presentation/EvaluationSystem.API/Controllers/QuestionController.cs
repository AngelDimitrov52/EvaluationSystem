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
        private IQuestionService answerService;
        public QuestionController(IQuestionService service)
        {
            answerService = service;
        }
        [HttpGet("{id}")]
        public QuestionDto GetAnswerById(int id)
        {
            QuestionDto result = answerService.GetById(id);

            return result;
        }

    }
}
