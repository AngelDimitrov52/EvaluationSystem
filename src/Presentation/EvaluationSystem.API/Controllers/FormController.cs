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

        [HttpGet("{formId}")]
        public FormGetDto GetById(int formId)
        {
            return _formService.GetById(formId);
        }

        [HttpPost]
        public FormGetDto Create([FromBody] FormCreateDto model)
        {
            return _formService.Create(model);
        }

        [HttpPut("{formId}")]
        public FormUpdateDto Update(int formId, [FromBody] FormUpdateDto model)
        {
            return _formService.Update(formId, model);
        }

        [HttpDelete("{formId}")]
        public IActionResult Delete(int formId)
        {
            _formService.Delete(formId);
            return NoContent();
        }
    }
}
