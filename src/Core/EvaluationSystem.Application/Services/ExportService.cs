using EvaluationSystem.Application.Models.AttestationAnswerModel.Interface;
using EvaluationSystem.Application.Models.AttestationFormModels.Interface;
using EvaluationSystem.Application.Models.AttestationModels.Interface;
using EvaluationSystem.Application.Models.AttestationParicipantModels.Interface;
using EvaluationSystem.Application.Models.Exceptions;
using EvaluationSystem.Application.Models.ExportModels.Dtos;
using EvaluationSystem.Application.Models.ExportModels.Interface;
using EvaluationSystem.Application.Models.UserModels.Interface;
using EvaluationSystem.Application.Services.HelpServices;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;
using System.Net;

namespace EvaluationSystem.Application.Services
{
    public class ExportService : IExportService
    {
        private readonly IAttestationRepository _attestationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAttestationFormService _attestationFormService;
        private readonly IUserAnswerService _userAnswerService;
        private readonly IAttestationParticipantRepository _attestationParticipantRepository;
        public ExportService(IAttestationRepository attestationRepository,
            IUserRepository userRepository,
            IAttestationFormService attesttionFormService, IUserAnswerService
            userAnswerService,
            IAttestationParticipantRepository attestationParticipantRepository)
        {
            _attestationRepository = attestationRepository;
            _userRepository = userRepository;
            _attestationFormService = attesttionFormService;
            _userAnswerService = userAnswerService;
            _attestationParticipantRepository = attestationParticipantRepository;
        }
    public ExportSelfAssessmentDto GetExportForSelfAssesmentForm(int attestationId)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<Attestation>(attestationId, _attestationRepository);
            var attestation = _attestationRepository.GetById(attestationId);
            var userToEval = _userRepository.GetById(attestation.IdUserToEval);

            var form = _attestationFormService.GetById(attestation.IdAttestationForm);
            if (form.Name != "SELF-ASSESSMENT")
            {
                throw new HttpException("The form is not SELF-ASSESSMENT", HttpStatusCode.BadRequest);
            }

            var result = new ExportSelfAssessmentDto();

            result.Labels = new List<string>();
            foreach (var module in form.Modules)
            {
                if (module.Name == "How well do I handle the job?")
                {
                    foreach (var question in module.Questions)
                    {
                        result.Labels.Add(question.Name);
                    }
                }
            }

            result.UserResult = new List<int>();
            var userToEvalForm = _userAnswerService.GetFormWhithCurrentAnswers(attestationId, userToEval.Email);
            foreach (var module in userToEvalForm.Modules)
            {
                if (module.Name == "How well do I handle the job?")
                {
                    foreach (var question in module.Questions)
                    {
                        foreach (var answer in question.Answers)
                        {
                            if (answer.IsAnswered == true)
                            {
                                result.UserResult.Add(int.Parse(answer.AnswerText));
                            }
                        }
                    }
                }
            }

            result.ParticipantResult = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };
            var partcipants = _attestationParticipantRepository.GetAllUserParticipatnByAttestationId(attestationId);
            foreach (var participantFromDb in partcipants)
            {
                if (participantFromDb.IdUserParticipant == userToEval.Id)
                {
                    continue;
                }

                var participant = _userRepository.GetById(participantFromDb.IdUserParticipant);
                var parcipantForm = _userAnswerService.GetFormWhithCurrentAnswers(attestationId, participant.Email);
                foreach (var module in parcipantForm.Modules)
                {
                    if (module.Name == "How well do I handle the job?")
                    {
                        for (int i = 0; i < module.Questions.Count; i++)
                        {
                            foreach (var answer in module.Questions[i].Answers)
                            {
                                if (answer.IsAnswered == true)
                                {
                                    result.ParticipantResult[i] += double.Parse(answer.AnswerText);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < result.ParticipantResult.Count; i++)
            {
                if (result.ParticipantResult[i] == 0 || partcipants.Count - 1 == 0)
                {
                    continue;
                }
                result.ParticipantResult[i] /= (partcipants.Count - 1);
            }

            return result;
        }
    }
}
