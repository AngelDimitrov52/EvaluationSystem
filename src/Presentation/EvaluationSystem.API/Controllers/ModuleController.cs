using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationSystem.API.Controllers
{
    [Route("api/module")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;
        public ModuleController(IModuleService service)
        {
            _moduleService = service;
        }

        [HttpGet]
        public List<ModuleGetDto> GetAll()
        {
            return _moduleService.GetAll();
        }

        [HttpGet("{id}")]
        public ModuleGetDto GetById(int id)
        {
            return _moduleService.GetById(id);
        }

        [HttpPost]
        public ModuleGetDto Create([FromBody] ModuleCreateDto model)
        {
            return _moduleService.Create(model);
        }

        [HttpPut("{id}")]
        public ModuleGetDto Update(int id, [FromBody] ModuleCreateDto model)
        {
            return _moduleService.Update(id, model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _moduleService.Delete(id);
            return NoContent();
        }

        [HttpPost("{moduleId}/question/{questionId}/position/{position}")]
        public IActionResult AddQuestionToModule(int moduleId, int questionId, int position)
        {
            _moduleService.AddQuestionToModule(moduleId, questionId, position);
            return Ok($"Added question with ID:{questionId} to module with ID:{moduleId} on position:{position}");
        }

        [HttpDelete("{moduleId}/question/{questionId}")]
        public IActionResult DeleteQuestionFromModule(int moduleId, int questionId)
        {
            _moduleService.DeleteQuestionToModule(moduleId, questionId);
            return NoContent();
        }

        [HttpGet("questions/{moduleId}")]
        public ModuleWithQuestionsDto GetmoduleWithQuestions(int moduleId)
        {
            return _moduleService.GetModuleWithQuestions(moduleId);
        }

    }
}
