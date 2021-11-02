
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Services.AnswerService;
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
    public class AnswerController : ControllerBase
    {
        private IAnswerService answerService;
        public AnswerController(IAnswerService service)
        {
            answerService = service;
        }

        [HttpGet]
        public List<AnswerDto> GetAllAnswer()
        {
            List<AnswerDto> result = answerService.GetAll();
            return result;
        }

        [HttpGet("{id}")]
        public AnswerDto GetAnswerById(int id)
        {
            AnswerDto result = answerService.GetById(id);
            return result;
        }

        [HttpPost]
        public AnswerDto CreateAnswer([FromBody] AnswerDto model)
        {
            AnswerDto result = answerService.Create(model);
            return result;
        }

        [HttpPut]
        public AnswerDto UpdateAnswer([FromBody] AnswerDto model)
        {
            AnswerDto result = answerService.Update(model);
            return result;
        }

        [HttpDelete("{id}")]
        public AnswerDto DeleteAnswer(int id)
        {
            AnswerDto result = answerService.Delete(id);
            return result;
        }
    }
}
