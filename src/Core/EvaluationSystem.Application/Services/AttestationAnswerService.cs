using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AttestationAnswerModel.Dtos;
using EvaluationSystem.Application.Models.AttestationAnswerModel.Interface;
using EvaluationSystem.Application.Models.AttestationModels.Interface;
using EvaluationSystem.Application.Models.Exceptions;
using EvaluationSystem.Application.Models.FormModels.Dtos;
using EvaluationSystem.Application.Models.FormModels.Interface;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using EvaluationSystem.Application.Models.QuestionModels.Intefaces;
using EvaluationSystem.Application.Models.UserModels.Interface;
using EvaluationSystem.Application.Services.HelpServices;
using EvaluationSystem.Domain.Entities;
using EvaluationSystem.Domain.Enums;
using System.Linq;
using System.Net;

namespace EvaluationSystem.Application.Services
{
    public class AttestationAnswerService : IAttestationAnswerService
    {
        private readonly IAttestationRepository _attestationRepository;
        private readonly IAttestationAnswerRepository _attestationAnswerRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IFormService _formService;
        private readonly IUserRepository _userRepository;
        private readonly IAttestationService _attestationService;
        private readonly IMapper _mapper;

        private readonly ICurrentUser _currentUser;
        public AttestationAnswerService(IAttestationAnswerRepository attestationAnswerRepository,
                                        IAttestationRepository attestationRepository,
                                        IModuleRepository moduleRepository,
                                        IQuestionRepository questionRepository,
                                        IAnswerRepository answerRepository,
                                        ICurrentUser currentUser,
                                        IFormService formService,
                                        IUserRepository userRepository,
                                        IAttestationService attestationService,
                                        IMapper mapper)
        {
            _attestationAnswerRepository = attestationAnswerRepository;
            _attestationRepository = attestationRepository;
            _moduleRepository = moduleRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _currentUser = currentUser;
            _formService = formService;
            _userRepository = userRepository;
            _attestationService = attestationService;
            _mapper = mapper;
        }
       
        public void Create(AttestationAnswerCreateDto attestationAnswerCreateDtos)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<Attestation>(attestationAnswerCreateDtos.AttestationId, _attestationRepository);
            foreach (var body in attestationAnswerCreateDtos.Body)
            {
                ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<ModuleTemplate>(body.ModuleId, _moduleRepository);
                ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(body.QuestionId, _questionRepository);

                var attestationAnswer = new AttestationAnswer
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
                        ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<AnswerTemplate>(answerId, _answerRepository);
                        attestationAnswer.IdAnswer = answerId;
                        attestationAnswer.TextAnswer = null;
                        _attestationAnswerRepository.Create(attestationAnswer);
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
                    _attestationAnswerRepository.Create(attestationAnswer);
                }
            }
            _attestationAnswerRepository.ChangeUserStatusToDone(attestationAnswerCreateDtos.AttestationId, _currentUser.Id);
        }
        public FormAttestationDto GetFormWhithCurrentAnswers(int attestationId, string participantEmail)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<Attestation>(attestationId, _attestationRepository);
            var attestation = _attestationRepository.GetById(attestationId);
            var formGet = _formService.GetById(attestation.IdFormTemplate);
            var participant = _userRepository.GetUserByEmail(participantEmail);
            var allAttestationAnswers = _attestationAnswerRepository.GetAllAttestationAnswerByUserAndAttestation(attestationId, participant.Id);

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
    }
}
