using AutoMapper;
using EvaluationSystem.Application.Models.FormModels.Dtos;
using EvaluationSystem.Application.Models.FormModels.Interface;
using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Services
{
    public class FormService : IFormService
    {
        private readonly IMapper _mapper;
        private readonly IFormRepository _formRepository;

        public FormService(IMapper mapper, IFormRepository repository)
        {
            _mapper = mapper;
            _formRepository = repository;
        }
        public List<FormGetDto> GetAll()
        {
            var forms = _formRepository.GetAll();
            return _mapper.Map<List<FormGetDto>>(forms);
        }
        public FormGetDto GetById(int id)
        {
            var form = _formRepository.GetById(id);
            return _mapper.Map<FormGetDto>(form);
        }
        public FormGetDto Create(FormCreateDto model)
        {
            var form = _mapper.Map<FormTemplate>(model);
            int formId = _formRepository.Create(form);
            form.Id = formId;
            return _mapper.Map<FormGetDto>(form);
        }
        public FormGetDto Update(int id, FormCreateDto model)
        {
            var form = _mapper.Map<FormTemplate>(model);
            form.Id = id;
            _formRepository.Update(form);
            return _mapper.Map<FormGetDto>(form);
        }
        public void Delete(int id)
        {
            _formRepository.Delete(id);
        }
    }
}
