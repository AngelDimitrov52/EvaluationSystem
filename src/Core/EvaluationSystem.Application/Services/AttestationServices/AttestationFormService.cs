using AutoMapper;
using EvaluationSystem.Application.Models.AttestationFormModels.Interface;
using EvaluationSystem.Application.Models.AttestationModuleModels.Interface;
using EvaluationSystem.Application.Models.FormModels.Dtos;
using EvaluationSystem.Application.Services.HelpServices;
using EvaluationSystem.Domain.Entities.AttestationEntities;

namespace EvaluationSystem.Application.Services.AttestationServices
{
    public class AttestationFormService : IAttestationFormService
    {
        private readonly IAttestationFormRepository _attestationFormRepository;
        private readonly IAttestationModuleService _attestationModuleService;
        private readonly IMapper _mapper;
        public AttestationFormService(IAttestationFormRepository attestationFormRepository, IMapper mapper, IAttestationModuleService attestationModuleService)
        {
            _attestationFormRepository = attestationFormRepository;
            _mapper = mapper;
            _attestationModuleService = attestationModuleService;
        }
        public FormGetDto GetById(int formId)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<AttestationForm>(formId, _attestationFormRepository);

            var formsName = _attestationFormRepository.GetById(formId);
            var form = _mapper.Map<FormGetDto>(formsName);
            form.Modules = _attestationModuleService.GetAllModules(formId);
            return form;
        }
        public int Create(FormCreateDto model)
        {
            var form = _mapper.Map<AttestationForm>(model);
            var formId = _attestationFormRepository.Create(form);
            form.Id = formId;

            foreach (var module in model.Modules)
            {
                _attestationModuleService.Create(formId, module);
            }
            return formId;
        }

        public void Delete(int formId)
        {
            var form = GetById(formId);
            _attestationFormRepository.DeleteFormFromFormModuleTable(formId);

            foreach (var module in form.Modules)
            {
                _attestationModuleService.Delete(module.Id);
            }
            _attestationFormRepository.Delete(formId);
        }
    }
}
