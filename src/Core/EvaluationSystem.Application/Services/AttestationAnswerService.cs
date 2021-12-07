using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AttestationAnswerModel.Dtos;
using EvaluationSystem.Application.Models.AttestationAnswerModel.Interface;
using EvaluationSystem.Application.Models.AttestationModels.Interface;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using EvaluationSystem.Application.Models.QuestionModels.Intefaces;
using EvaluationSystem.Application.Models.UserModels.Interface;
using EvaluationSystem.Application.Services.HelpServices;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Services
{
    public class AttestationAnswerService : IAttestationAnswerService
    {
        private readonly IMapper _mapper;
        private readonly IAttestationRepository _attestationRepository;
        private readonly IAttestationAnswerRepository _attestationAnswerRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IUserRepository _userRepository;
        public AttestationAnswerService(IMapper mapper,
                                        IAttestationAnswerRepository attestationAnswerRepository,
                                        IAttestationRepository attestationRepository,
                                        IModuleRepository moduleRepository,
                                        IQuestionRepository questionRepository,
                                        IAnswerRepository answerRepository,
                                        IUserRepository userRepository)
        {
            _mapper = mapper;
            _attestationAnswerRepository = attestationAnswerRepository;
            _attestationRepository = attestationRepository;
            _moduleRepository = moduleRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _userRepository = userRepository;
        }

        public void Create(List<AttestationAnswerCreateDto> attestationAnswerCreateDtos)
        {
            var attestationAnswers = _mapper.Map<List<AttestationAnswer>>(attestationAnswerCreateDtos);
            foreach (var entity in attestationAnswers)
            {
                ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<User>(entity.IdUserParticipant, _userRepository);
                ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<Attestation>(entity.IdAttestation, _attestationRepository);
                ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<ModuleTemplate>(entity.IdModule, _moduleRepository);
                ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(entity.IdQuestion, _questionRepository);
                ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<AnswerTemplate>(entity.IdAnswer, _answerRepository);

                _attestationAnswerRepository.Create(entity);
            }
        }
    }
}
