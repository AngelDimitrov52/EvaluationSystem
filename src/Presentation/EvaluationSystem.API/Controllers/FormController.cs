using EvaluationSystem.Application.Models.FormModels.Dtos;
using EvaluationSystem.Application.Models.FormModels.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvaluationSystem.API.Controllers
{
    [Route("api/form")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormService _formService;
        public FormController(IFormService service)
        {
            _formService = service;
        }

        [HttpGet]
        public List<FormGetDto> GetAll()
        {
            return _formService.GetAll();
        }

        [HttpGet("{id}")]
        public FormGetDto GetById(int id)
        {
            return _formService.GetById(id);
        }

        [HttpPost]
        public FormGetDto Create([FromBody] FormCreateDto model)
        {
            return _formService.Create(model);
        }

        [HttpPut("{id}")]
        public FormGetDto Update(int id, [FromBody] FormCreateDto model)
        {
            return _formService.Update(id, model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _formService.Delete(id);
            return NoContent();
        }

        [HttpPost("{formId}/module/{moduleId}")]
        public IActionResult AddModuleToForm(int formId, int moduleId, int position)
        {
            _formService.AddModuleToForm(formId, moduleId, position);
            return Ok($"Added module with ID:{moduleId} to form with ID:{formId} on position:{position}");
        }

        [HttpDelete("{formId}/module/{moduleId}")]
        public IActionResult DeleteModuleFromForm(int formId, int moduleId)
        {
            _formService.DeleteModuldeFromForm(formId, moduleId);
            return NoContent();
        }

        [HttpGet("GetAllModulesWithQuestions")]
        public FormWithModulesAndQuestionsDto GetAllModuleWithQuestions(int formId)
        {
            return _formService.GetFormWithModulesAndQuestions(formId);
        }

        [HttpGet("GetAllModules")]
        public FormWithModulesDto GetAllModule(int formId)
        {
            return _formService.GetFormWithModules(formId);
        }

        [HttpPut("{formId}/module/{moduleId}/position")]
        public IActionResult EditModulePositionInForm(int formId, int moduleId, int position)
        {
            _formService.EditModulePosition(formId, moduleId, position);
            return Ok($"Edit module with ID:{moduleId} to form with ID:{formId} on position:{position}");
        }
    }
}
