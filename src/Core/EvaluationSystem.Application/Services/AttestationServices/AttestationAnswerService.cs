using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Application.Models.AttestationAnswerModels.Interface;
using EvaluationSystem.Domain.Entities.AttestationEntities;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Services.AttestationServices
{
    public class AttestationAnswerService : IAttestationAnswerService
    {
        private readonly IAttestationAnswerRepository _attestationAnswerRepository;
        private readonly IMapper _mapper;
        public AttestationAnswerService(IAttestationAnswerRepository attestationAnswerRepository, IMapper mapper)
        {
            _attestationAnswerRepository = attestationAnswerRepository;
            _mapper = mapper;
        }

        public void Create(int questionId, AnswerCreateDto model)
        {
            var answer = _mapper.Map<AttestationAnswer>(model);
            answer.IdQuestion = questionId;
            _attestationAnswerRepository.Create(answer);
        }
        public List<AnswerGetDto> GetAll(int questionId)
        {
            var answers = _attestationAnswerRepository.GetAllByQuestionId(questionId);
            var answersGetDtos = _mapper.Map<List<AnswerGetDto>>(answers);

            return answersGetDtos;
        }
    }
}
