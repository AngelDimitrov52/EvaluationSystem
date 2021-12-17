﻿using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AttestationAnswerModel.Dtos;
using EvaluationSystem.Application.Models.AttestationAnswerModel.Interface;
using EvaluationSystem.Application.Models.AttestationAnswerModels.Interface;
using EvaluationSystem.Application.Models.AttestationFormModels.Interface;
using EvaluationSystem.Application.Models.AttestationModels.Interface;
using EvaluationSystem.Application.Models.AttestationModuleModels.Interface;
using EvaluationSystem.Application.Models.AttestationQuestionModels.Interface;
using EvaluationSystem.Application.Models.Exceptions;
using EvaluationSystem.Application.Models.FormModels.Dtos;
using EvaluationSystem.Application.Models.UserModels.Interface;
using EvaluationSystem.Application.Services.HelpServices;
using EvaluationSystem.Domain.Entities;
using EvaluationSystem.Domain.Entities.AttestationEntities;
using EvaluationSystem.Domain.Enums;
using System.Linq;
using System.Net;

namespace EvaluationSystem.Application.Services
{
    public class UserAnswerService : IUserAnswerService
    {
        private readonly IAttestationRepository _attestationRepository;
        private readonly IUserAnswerRepository _userAnswerRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAttestationFormService _attestationFormService;
        private readonly IAttestationModuleRepository _attestationModuleRepository;
        private readonly IAttestationQuestionRepository _attestationQuestionRepository;
        private readonly IAttestationAnswerRepository _attestationAnswerRepository;

        private readonly ICurrentUser _currentUser;
        public UserAnswerService(IUserAnswerRepository userAnswerRepository,
                                 IAttestationRepository attestationRepository,
                                 IAnswerRepository answerRepository,
                                 ICurrentUser currentUser,
                                 IUserRepository userRepository,
                                 IMapper mapper,
                                 IAttestationFormService attestationFormService,
                                 IAttestationModuleRepository attestationModuleRepository,
                                 IAttestationQuestionRepository attestationQuestionRepository,
                                 IAttestationAnswerRepository attestationAnswerRepository)
        {
            _userAnswerRepository = userAnswerRepository;
            _attestationRepository = attestationRepository;
            _answerRepository = answerRepository;
            _currentUser = currentUser;
            _userRepository = userRepository;
            _mapper = mapper;
            _attestationFormService = attestationFormService;
            _attestationModuleRepository = attestationModuleRepository;
            _attestationQuestionRepository = attestationQuestionRepository;
            _attestationAnswerRepository = attestationAnswerRepository;
        }

        public FormAttestationDto GetFormWhithCurrentAnswers(int attestationId, string participantEmail)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<Attestation>(attestationId, _attestationRepository);
            var attestation = _attestationRepository.GetById(attestationId);
            var formGet = _attestationFormService.GetById(attestation.IdAttestationForm);
            var participant = _userRepository.GetUserByEmail(participantEmail);
            var allAttestationAnswers = _userAnswerRepository.GetAllAttestationAnswerByUserAndAttestation(attestationId, participant.Id);

            var resultForm = _mapper.Map<FormAttestationDto>(formGet);

            foreach (var attestationAnswer in allAttestationAnswers)
            {
                var module = resultForm.Modules.Where(m => m.Id == attestationAnswer.IdModule).FirstOrDefault();
                var question = module.Questions.Where(q => q.Id == attestationAnswer.IdQuestion).FirstOrDefault();

                if (question.Type == AnswersTypes.TextField)
                {
                    question.TextAnswer = attestationAnswer.TextAnswer;
                }
                else
                {
                    foreach (var answer in question.Answers)
                    {
                        if (answer.Id == attestationAnswer.IdAnswer)
                        {
                            answer.IsAnswered = true;
                        }
                    }
                }
            }
            return resultForm;
        }
        public void Create(UserAnswerCreateDto attestationAnswerCreateDtos)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<Attestation>(attestationAnswerCreateDtos.AttestationId, _attestationRepository);
            foreach (var body in attestationAnswerCreateDtos.Body)
            {
                if (_attestationModuleRepository.GetById(body.ModuleId) == null)
                {
                    throw new HttpException($"Module with ID:{body.ModuleId} doesn't exist!", HttpStatusCode.NotFound);
                }
                if (_attestationQuestionRepository.GetById(body.QuestionId) == null)
                {
                    throw new HttpException($"Question with ID:{body.QuestionId} doesn't exist!", HttpStatusCode.NotFound);
                }

                var attestationAnswer = new UserAnswer
                {
                    IdAttestation = attestationAnswerCreateDtos.AttestationId,
                    IdUserParticipant = _currentUser.Id,
                    IdModule = body.ModuleId,
                    IdQuestion = body.QuestionId,
                };
                if (body.AnswerIds.Count != 0)
                {
                    foreach (var answerId in body.AnswerIds)
                    {
                        ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<AttestationAnswer>(answerId, _attestationAnswerRepository);
                        attestationAnswer.IdAnswer = answerId;
                        attestationAnswer.TextAnswer = null;
                        _userAnswerRepository.Create(attestationAnswer);
                    }
                }
                else
                {
                    if (body.AnswerText == null || body.AnswerText == "")
                    {
                        throw new HttpException("AnswerText is empty!", HttpStatusCode.BadRequest);
                    }
                    attestationAnswer.IdAnswer = null;
                    attestationAnswer.TextAnswer = body.AnswerText;
                    _userAnswerRepository.Create(attestationAnswer);
                }
            }
            _userAnswerRepository.ChangeUserStatusToDone(attestationAnswerCreateDtos.AttestationId, _currentUser.Id);
        }
        public void DeleteWithAttestationId(int atteatationId)
        {
            _userAnswerRepository.DeleteWithAttestationId(atteatationId);
        }
    }
}