using AutoMapper;
using EvaluationSystem.Application.Models.AttestationModels.Dtos;
using EvaluationSystem.Application.Models.AttestationModels.Interface;
using EvaluationSystem.Application.Models.Exceptions;
using EvaluationSystem.Application.Models.FormModels.Interface;
using EvaluationSystem.Application.Models.UserModels.Dtos;
using EvaluationSystem.Application.Models.UserModels.Interface;
using EvaluationSystem.Application.Services.HelpServices;
using EvaluationSystem.Domain.Entities;
using EvaluationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace EvaluationSystem.Application.Services
{
    public class AttestationService : IAttestationService
    {
        private readonly string _inProgerss = "In Progress";
        private readonly IAttestationRepository _attestationRepository;
        private readonly IFormRepository _formRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AttestationService(IAttestationRepository attestationRepository, IFormRepository formRepository, IUserRepository userRepository, IMapper mapper)
        {
            _attestationRepository = attestationRepository;
            _formRepository = formRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<AttestationGetDto> GetAll()
        {
            var attestationsFormDb = _attestationRepository.GetAllAttestations();
            var result = new List<AttestationGetDto>();
            var status = AttestationStatus.Open.ToString();

            foreach (var attestationDb in attestationsFormDb)
            {
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
                    attestation.Status = _inProgerss;
                }
            }
            return SetAttestationStatus(result);
        }
        public AttestationGetDto Create(AttestationCreateDto model)
        {
            var formId = model.FormId;
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<FormTemplate>(formId, _formRepository);

            var user = _userRepository.GetUserByEmail(model.User.Email);
            if (user == null)
            {
                var userName = model.User.Name;
                user = new User { Name = userName, Email = model.User.Email };
                var id = _userRepository.Create(user);
                user.Id = id;
            }
            if (model.Participants.Count == 0)
            {
                throw new HttpException("Participants count can't be zero!", HttpStatusCode.BadRequest);
            }
            var participants = new List<UserEvaluatorCreateDto>();
            foreach (var participant in model.Participants)
            {
                if (!participants.Any(x => x.Email == participant.Email))
                {
                    participants.Add(participant);
                }
            }
            var usersParticipantCreateDtos = _mapper.Map<List<UserParticipantCreateDto>>(participants);
            foreach (var participant in usersParticipantCreateDtos)
            {
                var part = _userRepository.GetUserByEmail(participant.Email);
                if (part == null)
                {
                    var partName = participant.Name;
                    part = new User { Name = partName, Email = participant.Email };
                    var id = _userRepository.Create(part);
                    part.Id = id;
                }
                participant.Id = part.Id;
            }

            var attestationToCreate = new Attestation { IdFormTemplate = formId, IdUserToEval = user.Id, CreateDate = DateTime.Now };
            var attestationId = _attestationRepository.Create(attestationToCreate);
            foreach (var participant in usersParticipantCreateDtos)
            {
                _attestationRepository.AddParticipantToAttestation(attestationId, participant.Id, participant.Position);
            }

            var form = _formRepository.GetById(formId);
            var status = AttestationStatus.Open;

            var attestation = new AttestationGetDto
            {
                Id = attestationId,
                DateOfCreation = DateTime.Now,
                UserName = user.Name,
                FormName = form.Name,
                Status = status.ToString(),
                Participants = new List<ParticipantGetDto>()
            };
            attestation.Participants.AddRange(from participantCreate in usersParticipantCreateDtos
                                              let participant = _userRepository.GetById(participantCreate.Id)
                                              select new ParticipantGetDto { Name = participant.Name, ParticipantStatus = status });
            return attestation;
        }

        public void Delete(int attestationId)
        {
            _attestationRepository.DeleteAttestationFromAttestationParticipant(attestationId);
            _attestationRepository.DeleteAttestationFromAttestationTable(attestationId);
        }
        private List<AttestationGetDto> SetAttestationStatus(List<AttestationGetDto> model)
        {
            foreach (var att in model)
            {
                if (att.Status == _inProgerss)
                {
                    foreach (var participant in att.Participants)
                    {
                        if (participant.ParticipantStatus == AttestationStatus.Open)
                        {
                            att.Status = _inProgerss;
                            break;
                        }
                        else
                        {
                            att.Status = AttestationStatus.Done.ToString();
                        }
                    }
                }
            }
            return model;
        }
    }
}
