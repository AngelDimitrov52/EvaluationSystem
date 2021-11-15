using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IMapper _mapper;
        private readonly IAnswerRepository _answerRepository;


        public AnswerService(IMapper mapper, IAnswerRepository repository)
        {
            _mapper = mapper;
            _answerRepository = repository;
        }

        public List<AnswerGetDto> GetAll(int questionId)
        {
            var answers = _answerRepository.GetAllByQuestionId(questionId);
            return _mapper.Map<List<AnswerGetDto>>(answers);
        }

        public AnswerGetDto GetById(int id)
        {
            var answer = _answerRepository.GetById(id);
            IsEntityIsNull(answer);

            return _mapper.Map<AnswerGetDto>(answer);
        }

        public void Delete(int id)
        {
            _answerRepository.Delete(id);
        }

        public AnswerGetDto Create(int questionId, AnswerCreateDto model)
        {
            var answer = _mapper.Map<AnswerTemplate>(model);
            answer.IdQuestion = questionId;
            int answerId = _answerRepository.Create(answer);
            answer.Id = answerId;

            return _mapper.Map<AnswerGetDto>(answer);
        }

        public AnswerGetDto Update(int questionId, int id, AnswerCreateDto model)
        {
            var entity = _answerRepository.GetById(id);
            IsEntityIsNull(entity);

            var answer = _mapper.Map<AnswerTemplate>(model);
            answer.IdQuestion = questionId;
            answer.Id = id;
            _answerRepository.Update(answer);

            return _mapper.Map<AnswerGetDto>(answer);
        }

        private void IsEntityIsNull(AnswerTemplate entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Invalid answer id");
            }
        }
    }
}
