using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvaluationSystem.API.Controllers
{
    [Route("api/form/{formId}/module")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;
        public ModuleController(IModuleService service)
        {
            _moduleService = service;
        }

        [HttpGet]
        public List<ModuleGetDto> GetAll(int formId)
        {
            return _moduleService.GetAllModules(formId);
        }

        [HttpGet("{moduleId}")]
        public ModuleGetDto GetById(int formId, int moduleId)
        {
            return _moduleService.GetById(formId, moduleId);
        }

        [HttpPost]
        public ModuleGetDto Create(int formId, [FromBody] ModuleCreateDto model)
        {
            return _moduleService.Create(formId, model);
        }

        [HttpPut("{moduleId}")]
        public ModuleUpdateDto Update(int formId, int moduleId, [FromBody] ModuleUpdateDto model)
        {
            return _moduleService.Update(formId, moduleId, model);
        }

        [HttpDelete("{moduleId}")]
        public IActionResult Delete(int formId, int moduleId)
        {
            _moduleService.Delete(moduleId);
            return NoContent();
        }
    }
}
