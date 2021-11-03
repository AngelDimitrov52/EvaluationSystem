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
        public List<AnswerGetDto> GetAll(int id)
        {
            var allAnswers = _repository.GetAll();
            var answers = allAnswers.Where(x => x.QuestionId == id);
            return _mapper.Map<List<AnswerGetDto>>(answers);
        }
        public AnswerGetDto GetById(int questionId, int id)
        {
            var аnswer = _repository.GetById(questionId, id);
            if (аnswer == null)
            {
                throw new Exception($"There is no answer with id:{id} in question with id:{questionId}!");
            }
            return _mapper.Map<AnswerGetDto>(аnswer);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public AnswerGetDto Create(int questionId, AnswerCreateDto model)
        {
            var answer = _mapper.Map<Аnswer>(model);
            answer.QuestionId = questionId;
            var result = _repository.AddNew(answer);

            return _mapper.Map<AnswerGetDto>(result);
        }

        public AnswerGetDto Update(int questionId, int id, AnswerCreateDto model)
        {
            var answer = _mapper.Map<Аnswer>(model);
            answer.QuestionId = questionId;
            answer.Id = id;

            var result = _repository.Update(answer);
            return _mapper.Map<AnswerGetDto>(result);
        }
    }
}
