using AutoMapper;
using EvaluationSystem.Application.Models.Exceptions;
using EvaluationSystem.Application.Models.FormModels.Interface;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Application.Models.QuestionModels.Intefaces;
using EvaluationSystem.Application.Services.HelpServices;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace EvaluationSystem.Application.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IMapper _mapper;
        private readonly IModuleRepository _moduleRepository;
        private readonly IQuestionService _questionService;
        private readonly IFormRepository _formRepository;

        public ModuleService(IMapper mapper, IModuleRepository repository, IQuestionService questionService, IFormRepository formRepository)
        {
            _mapper = mapper;
            _moduleRepository = repository;
            _formRepository = formRepository;
            _questionService = questionService;
        }
        public List<ModuleGetDto> GetAllModules(int formId)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<FormTemplate>(formId, _formRepository);

            var resultModules = new List<ModuleGetDto>();
            var modulesInForm = _moduleRepository.GetFormModulesByFormId(formId);
            foreach (var moduleInForm in modulesInForm)
            {
                var module = _moduleRepository.GetById(moduleInForm.IdModule);
                var mapModule = _mapper.Map<ModuleGetDto>(module);
                mapModule.Questions = _questionService.GetAll(mapModule.Id);
                mapModule.Position = moduleInForm.Position;
                resultModules.Add(mapModule);
            }
            return resultModules;
        }
        public ModuleGetDto GetById(int formId, int moduleId)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<FormTemplate>(formId, _formRepository);
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<ModuleTemplate>(moduleId, _moduleRepository);

            var moduleName = _moduleRepository.GetById(moduleId);
            var module = _mapper.Map<ModuleGetDto>(moduleName);

            var modulePosition = _moduleRepository.GetFormModulesByFormId(formId).Where(x => x.IdModule == moduleId && x.IdForm == formId).FirstOrDefault();
            if (modulePosition == null)
            {
                throw new HttpException($"Module with ID:{moduleId} doesn't exist in form with ID:{formId}!", HttpStatusCode.BadRequest);
            }
            module.Position = modulePosition.Position;

            module.Questions = _questionService.GetAll(module.Id);
            return module;
        }
        public ModuleGetDto Create(int formId, ModuleCreateDto model)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<FormTemplate>(formId, _formRepository);

            var module = _mapper.Map<ModuleTemplate>(model);
            int moduleId = _moduleRepository.Create(module);
            module.Id = moduleId;
            _moduleRepository.AddModuleToForm(formId, moduleId, model.Position);
            var createModule = _mapper.Map<ModuleGetDto>(module);
            createModule.Position = model.Position;
            createModule.Questions = new List<QuestionGetDto>();

            foreach (var question in model.Questions)
            {
                var insertQuestion = _questionService.Create(moduleId, question);
                createModule.Questions.Add(insertQuestion);
            }
            return createModule;
        }
        public void Delete(int moduleId)
        {
            var module = _moduleRepository.GetById(moduleId);
            var moduleDto = _mapper.Map<ModuleGetDto>(module);
            moduleDto.Questions = _questionService.GetAll(module.Id);

            _moduleRepository.DeleteModuleFromFormModuleTable(moduleId);
            _moduleRepository.DeleteModuleFromModuleQuestionTable(moduleId);

            foreach (var question in moduleDto.Questions)
            {
                _questionService.Delete(question.Id);
            }
            _moduleRepository.Delete(moduleId);
        }
        public ModuleGetDto Update(int id, ModuleCreateDto model)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<ModuleTemplate>(id, _moduleRepository);

            var module = _mapper.Map<ModuleTemplate>(model);
            module.Id = id;
            _moduleRepository.Update(module);

            return _mapper.Map<ModuleGetDto>(module);
        }

    }
}

