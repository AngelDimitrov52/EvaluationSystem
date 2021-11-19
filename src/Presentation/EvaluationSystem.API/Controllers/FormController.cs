using EvaluationSystem.Application.Models.FormModels.Dtos;
using EvaluationSystem.Application.Models.FormModels.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
