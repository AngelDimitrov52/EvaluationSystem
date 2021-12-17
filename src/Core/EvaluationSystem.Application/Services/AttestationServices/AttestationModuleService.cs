using AutoMapper;
using EvaluationSystem.Application.Models.AttestationModuleModels.Interface;
using EvaluationSystem.Application.Models.AttestationQuestionModels.Interface;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Domain.Entities.AttestationEntities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Services.AttestationServices
{
    public class AttestationModuleService : IAttestationModuleService
    {
        private readonly IAttestationModuleRepository _attestationModuleRepository;
        private readonly IAttestationQuestionService _attestationQuestionService;
        private readonly IMapper _mapper;
        public AttestationModuleService(IAttestationModuleRepository attestationModuleRepository, IMapper mapper, IAttestationQuestionService attestationQuestionService)
        {
            _attestationModuleRepository = attestationModuleRepository;
            _mapper = mapper;
            _attestationQuestionService = attestationQuestionService;
        }

        public void Create(int formId, ModuleCreateDto model)
        {
            var module = _mapper.Map<AttestationModule>(model);
            int moduleId = _attestationModuleRepository.Create(module);
            _attestationModuleRepository.AddAttestationModuleToAttestatationForm(formId, moduleId, model.Position);

            foreach (var question in model.Questions)
            {
                _attestationQuestionService.Create(moduleId, question);
            }
        }
        public List<ModuleGetDto> GetAllModules(int formId)
        {
            var resultModules = new List<ModuleGetDto>();
            var modulesInForm = _attestationModuleRepository.GetFormModulesByFormId(formId);
            foreach (var moduleInForm in modulesInForm)
            {
                var module = _attestationModuleRepository.GetById(moduleInForm.IdModule);
                var mapModule = _mapper.Map<ModuleGetDto>(module);
                mapModule.Questions = _attestationQuestionService.GetAll(mapModule.Id);
                mapModule.Position = moduleInForm.Position;
                resultModules.Add(mapModule);
            }
            return resultModules;
        }
        public void Delete(int moduleId)
        {
            var module = _attestationModuleRepository.GetById(moduleId);
            var moduleDto = _mapper.Map<ModuleGetDto>(module);
            moduleDto.Questions = _attestationQuestionService.GetAll(module.Id);

            _attestationModuleRepository.DeleteModuleFromFormModuleTable(moduleId);
            _attestationModuleRepository.DeleteModuleFromModuleQuestionTable(moduleId);

            foreach (var question in moduleDto.Questions)
            {
                _attestationQuestionService.Delete(question.Id);
            }
            _attestationModuleRepository.Delete(moduleId);
        }

    }
}
