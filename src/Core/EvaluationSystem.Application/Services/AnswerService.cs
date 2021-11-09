using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Services.AnswerService
{
    public class AnswerService : IAnswerService
    {
        private readonly IMapper _mapper;
        private readonly IAnswerRepository _repository;

        public AnswerService(IMapper mapper, IAnswerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public List<AnswerGetDto> GetAll(int questionId)
        {
            var answers = _repository.GetAll(questionId);
            return _mapper.Map<List<AnswerGetDto>>(answers);
        }

        public AnswerGetDto GetById(int id)
        {
            var answer = _repository.GetById(id);
            return _mapper.Map<AnswerGetDto>(answer);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public AnswerGetDto Create(int questionId, AnswerCreateDto model)
        {
            var answerToCreate = _mapper.Map<AnswerCreateDbDto>(model);
            answerToCreate.IdQuestion = questionId;
            int answerId = _repository.AddNew(answerToCreate);

            var answerEntity = _mapper.Map<Аnswer>(model);
            answerEntity.AnswerId = answerId;

            return _mapper.Map<AnswerGetDto>(answerEntity); ;
        }

        public AnswerGetDto Update(int questionId, int id, AnswerCreateDto model)
        {
            var answer = _mapper.Map<Аnswer>(model);
            answer.IdQuestion = questionId;
            answer.AnswerId = id;
            _repository.Update(answer);

            return _mapper.Map<AnswerGetDto>(answer);
        }
    }
}
