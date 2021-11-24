using AutoMapper;
using EvaluationSystem.Application.Models.FormModels.Dtos;
using EvaluationSystem.Application.Models.FormModels.Interface;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using EvaluationSystem.Application.Services.HelpServices;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationSystem.Application.Services
{
    public class FormService : IFormService
    {
        private readonly IMapper _mapper;
        private readonly IFormRepository _formRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly IModuleService _moduleService;

        public FormService(IMapper mapper, IFormRepository repository, IModuleRepository moduleRepository, IModuleService moduleService)
        {
            _mapper = mapper;
            _formRepository = repository;
            _moduleRepository = moduleRepository;
            _moduleService = moduleService;
        }
        public List<FormGetDto> GetAll()
        {
            var forms = _formRepository.GetAll();
            return _mapper.Map<List<FormGetDto>>(forms);
        }
        public FormGetDto GetById(int id)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<FormTemplate>(id, _formRepository);

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
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<FormTemplate>(id, _formRepository);

            var form = _mapper.Map<FormTemplate>(model);
            form.Id = id;
            _formRepository.Update(form);
            return _mapper.Map<FormGetDto>(form);
        }
        public void Delete(int formId)
        {
            var modules = _formRepository.GetFormModules(formId);
            foreach (var module in modules)
            {
                _formRepository.DeleteModuleFromForm(formId, module.IdModule);
            }
            _formRepository.Delete(formId);
        }
        public void AddModuleToForm(int formId, int moduleId, int position)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<FormTemplate>(formId, _formRepository);
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<ModuleTemplate>(moduleId, _moduleRepository);

            _formRepository.AddModuleToForm(formId, moduleId, position);
        }

        public void DeleteModuldeFromForm(int formId, int moduleId)
        {
            _formRepository.DeleteModuleFromForm(formId, moduleId);
        }

        public FormWithModulesAndQuestionsDto GetFormWithModulesAndQuestions(int formId)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<FormTemplate>(formId, _formRepository);

            var formEntity = _formRepository.GetById(formId);
            var form = _mapper.Map<FormWithModulesAndQuestionsDto>(formEntity);
            form.Modules = new List<ModuleWithQuestionsDto>();

            var modules = _formRepository.GetFormModules(formId);
            form.Modules.AddRange(from module in modules
                                  let moduleWithQuestoins = _moduleService.GetModuleWithQuestions(module.IdModule)
                                  select moduleWithQuestoins);
            return form;
        }
        public FormWithModulesDto GetFormWithModules(int formId)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<FormTemplate>(formId, _formRepository);

            var formEntity = _formRepository.GetById(formId);
            var form = _mapper.Map<FormWithModulesDto>(formEntity);
            form.Modules = new List<ModuleGetDto>();

            var modules = _formRepository.GetFormModules(formId);
            form.Modules.AddRange(from module in modules
                                  let result = _mapper.Map<ModuleGetDto>(_moduleService.GetById(module.IdModule))
                                  select result);
            return form;
        }
    }
}
