using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Intefaces;
using EvaluationSystem.Application.Services.HelpServices;
using EvaluationSystem.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IMapper _mapper;
        private readonly IAnswerRepository _answerRepository;
        private readonly IQuestionRepository _questionRepository;

        public AnswerService(IMapper mapper, IAnswerRepository repository, IQuestionRepository questionRepository)
        {
            _mapper = mapper;
            _answerRepository = repository;
            _questionRepository = questionRepository;
        }

        public List<AnswerGetDto> GetAll(int questionId)
        {

            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(questionId, _questionRepository);

            var answers = _answerRepository.GetAllByQuestionId(questionId);
            var answersGetDtos = _mapper.Map<List<AnswerGetDto>>(answers);

            return answersGetDtos;
        }

        public AnswerGetDto GetById(int id)
        {
            var answer = _answerRepository.GetById(id);
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<AnswerTemplate>(id, _answerRepository);

            var answerGetDto = _mapper.Map<AnswerGetDto>(answer);
            return answerGetDto;
        }

        public AnswerGetDto Create(int questionId, AnswerCreateDto model)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(questionId, _questionRepository);

            var answer = _mapper.Map<AnswerTemplate>(model);
            answer.IdQuestion = questionId;
            int answerId = _answerRepository.Create(answer);
            answer.Id = answerId;

            return _mapper.Map<AnswerGetDto>(answer);
        }

        public AnswerGetDto Update(int questionId, int id, AnswerCreateDto model)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(questionId, _questionRepository);
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<AnswerTemplate>(id, _answerRepository);

            var answer = _mapper.Map<AnswerTemplate>(model);

            answer.IdQuestion = questionId;
            answer.Id = id;
            _answerRepository.Update(answer);

            return _mapper.Map<AnswerGetDto>(answer);
        }
        public void Delete(int id)
        {
            _answerRepository.Delete(id);
        }
    }
}
