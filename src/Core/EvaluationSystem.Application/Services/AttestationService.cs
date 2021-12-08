using EvaluationSystem.Application.Models.AttestationModels.Dtos;
using EvaluationSystem.Application.Models.AttestationModels.Interface;
using EvaluationSystem.Application.Models.FormModels.Interface;
using EvaluationSystem.Application.Models.UserModels.Interface;
using EvaluationSystem.Application.Services.HelpServices;
using EvaluationSystem.Domain.Entities;
using EvaluationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationSystem.Application.Services
{
    public class AttestationService : IAttestationService
    {
        private readonly IAttestationRepository _attestationRepository;
        private readonly IFormRepository _formRepository;
        private readonly IUserRepository _userRepository;

        public AttestationService(IAttestationRepository attestationRepository, IFormRepository formRepository, IUserRepository userRepository)
        {
            _attestationRepository = attestationRepository;
            _formRepository = formRepository;
            _userRepository = userRepository;
        }

        public List<AttestationGetDto> GetAll()
        {
            var attestationsFormDb = _attestationRepository.GetAllAttestations();
            List<AttestationGetDto> result = new List<AttestationGetDto>();

            foreach (var attestationDb in attestationsFormDb)
            {
                var status = AttestationStatus.Open;
                var attestation = result.FirstOrDefault(x => x.Id == attestationDb.Id);
                if (attestation == null)
                {
                    attestation = new AttestationGetDto
                    {
                        Id = attestationDb.Id,
                        FormName = attestationDb.FormName,
                        DateOfCreation = attestationDb.CreateDate,
                        UserName = attestationDb.UserName,
                        Status = status,
                        Participants = new List<ParticipantGetDto>()
                    };
                    result.Add(attestation);
                }
                attestation.Participants.Add(new ParticipantGetDto
                {
                    ParticipantStatus = attestationDb.Status,
                    Name = attestationDb.ParticipantName
                });

                if (attestationDb.Status == AttestationStatus.Done)
                {
                    attestation.Status = AttestationStatus.InProgress;
                }
            }
            return SetAttestationStatus(result);
        }
        public AttestationGetDto Create( AttestationCreateDto model)
        {
            int userId = model.UserId;
            int formId = model.FormId;
            List<int> participantsIds = model.ParticipantsIds;
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<User>(userId, _userRepository);
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<FormTemplate>(formId, _formRepository);
            foreach (var participantId in participantsIds)
            {
                ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<User>(participantId, _userRepository);
            }

            var attestationToCreate = new Attestation { IdFormTemplate = formId, IdUserToEval = userId, CreateDate = DateTime.Now };
            var attestationId = _attestationRepository.Create(attestationToCreate);
            foreach (var participantId in participantsIds)
            {
                _attestationRepository.AddParticipantToAttestation(attestationId, participantId);
            }

            var user = _userRepository.GetById(userId);
            var form = _formRepository.GetById(formId);
            var status = AttestationStatus.Open;

            var attestation = new AttestationGetDto
            {
                Id = attestationId,
                DateOfCreation = DateTime.Now,
                UserName = user.Name,
                FormName = form.Name,
                Status = status,
                Participants = new List<ParticipantGetDto>()
            };
            attestation.Participants.AddRange(from participantId in participantsIds
                                              let participant = _userRepository.GetById(participantId)
                                              select new ParticipantGetDto { Name = participant.Name, ParticipantStatus = status });
            return attestation;
        }
        public void Delete(int attestationId)
        {
            _attestationRepository.DeleteAttestationFromAttestationParticipant(attestationId);
            _attestationRepository.DeleteAttestationFromAttestationTable(attestationId);
        }
        private List<AttestationGetDto> SetAttestationStatus(List<AttestationGetDto> result)
        {
            foreach (var att in result)
            {
                if (att.Status == AttestationStatus.InProgress)
                {
                    foreach (var participant in att.Participants)
                    {
                        if (participant.ParticipantStatus == AttestationStatus.Open)
                        {
                            att.Status = AttestationStatus.InProgress;
                            break;
                        }
                        else
                        {
                            att.Status = AttestationStatus.Done;
                        }
                    }
                }
            }
            return result;
        }
    }
}
