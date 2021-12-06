using AutoMapper;
using EvaluationSystem.Application.Models.AttestationModels.Interface;
using EvaluationSystem.Application.Models.FormModels.Dtos;
using EvaluationSystem.Application.Models.FormModels.Interface;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using EvaluationSystem.Application.Services.HelpServices;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Services
{
    public class FormService : IFormService
    {
        private readonly IMapper _mapper;
        private readonly IFormRepository _formRepository;
        private readonly IModuleService _moduleService;
        private readonly IAttestationService _attestation;

        public FormService(IMapper mapper, IFormRepository repository, IModuleService moduleService, IAttestationService attestation)
        {
            _mapper = mapper;
            _formRepository = repository;
            _moduleService = moduleService;
            _attestation = attestation;
        }
        public List<FormGetDto> GetAll()
        {
            var formsNames = _formRepository.GetAll();
            var forms = _mapper.Map<List<FormGetDto>>(formsNames);
            foreach (var form in forms)
            {
                form.Modules = _moduleService.GetAllModules(form.Id);
            }
            return forms;
        }
        public FormGetDto GetById(int formId)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<FormTemplate>(formId, _formRepository);

            var formsName = _formRepository.GetById(formId);
            var form = _mapper.Map<FormGetDto>(formsName);
            form.Modules = _moduleService.GetAllModules(formId);
            return form;
        }
        public FormGetDto Create(FormCreateDto model)
        {
            var form = _mapper.Map<FormTemplate>(model);
            int formId = _formRepository.Create(form);
            form.Id = formId;
            var createForm = _mapper.Map<FormGetDto>(form);
            createForm.Modules = new List<ModuleGetDto>();
            foreach (var module in model.Modules)
            {
                var insertModule = _moduleService.Create(formId, module);
                createForm.Modules.Add(insertModule);
            }
            return createForm;
        }
        public FormUpdateDto Update(int id, FormUpdateDto model)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<FormTemplate>(id, _formRepository);

            var form = _mapper.Map<FormTemplate>(model);
            form.Id = id;
            _formRepository.Update(form);
            return _mapper.Map<FormUpdateDto>(form);
        }
        public void Delete(int formId)
        {
            var attestations = _formRepository.GetAllAttestationsWithFormId(formId);
            foreach (var attestation in attestations)
            {
                _attestation.Delete(attestation.Id);
            }
            var form = GetById(formId);
            _formRepository.DeleteFormFromFormModuleTable(formId);

            foreach (var module in form.Modules)
            {
                _moduleService.Delete(module.Id);
            }
            _formRepository.Delete(formId);
        }
    }
}
