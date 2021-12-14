using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AttestationAnswerModel.Dtos;
using EvaluationSystem.Application.Models.AttestationAnswerModel.Interface;
using EvaluationSystem.Application.Models.AttestationModels.Interface;
using EvaluationSystem.Application.Models.Exceptions;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using EvaluationSystem.Application.Models.QuestionModels.Intefaces;
using EvaluationSystem.Application.Models.UserModels.Interface;
using EvaluationSystem.Application.Services.HelpServices;
using EvaluationSystem.Domain.Entities;
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

        private readonly ICurrentUser _currentUser;
        public AttestationAnswerService(IAttestationAnswerRepository attestationAnswerRepository,
                                        IAttestationRepository attestationRepository,
                                        IModuleRepository moduleRepository,
                                        IQuestionRepository questionRepository,
                                        IAnswerRepository answerRepository,
                                        ICurrentUser currentUser)
        {
            _attestationAnswerRepository = attestationAnswerRepository;
            _attestationRepository = attestationRepository;
            _moduleRepository = moduleRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _currentUser = currentUser;
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
    }
}
