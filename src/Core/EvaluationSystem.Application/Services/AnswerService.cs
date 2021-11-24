using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Application.Models.QuestionModels;
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
        private readonly IMemoryCache _memoryCache;

        public AnswerService(IMapper mapper, IAnswerRepository repository, IMemoryCache memoryCache, IQuestionService questionService, IQuestionRepository questionRepository)
        {
            _mapper = mapper;
            _answerRepository = repository;
            _memoryCache = memoryCache;
            _questionRepository = questionRepository;
        }

        public List<AnswerGetDto> GetAll(int questionId)
        {
            var answerCache = _memoryCache.Get($"allAnswer_{questionId}");
            if (answerCache != null)
            {
                return (List<AnswerGetDto>)answerCache;
            }

            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(questionId, _questionRepository);

            var answers = _answerRepository.GetAllByQuestionId(questionId);
            var answersGetDtos = _mapper.Map<List<AnswerGetDto>>(answers);

            _memoryCache.Set($"allAnswer_{questionId}", answersGetDtos);
            return answersGetDtos;
        }

        public AnswerGetDto GetById(int id)
        {
            var answerCache = _memoryCache.Get($"answer_{id}");
            if (answerCache != null)
            {
                return (AnswerGetDto)answerCache;
            }

            var answer = _answerRepository.GetById(id);
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<AnswerTemplate>(id, _answerRepository);

            var answerGetDto = _mapper.Map<AnswerGetDto>(answer);
            _memoryCache.Set($"answer_{id}", answerGetDto);

            return answerGetDto;
        }

        public AnswerGetDto Create(int questionId, AnswerCreateDto model)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(questionId, _questionRepository);

            var answer = _mapper.Map<AnswerTemplate>(model);
            answer.IdQuestion = questionId;
            int answerId = _answerRepository.Create(answer);
            answer.Id = answerId;

            ClearMemoryCache();
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

            ClearMemoryCache();
            return _mapper.Map<AnswerGetDto>(answer);
        }
        public void Delete(int id)
        {
            ClearMemoryCache();
            _answerRepository.Delete(id);
        }
        public void ClearMemoryCache()
        {
            if (_memoryCache is MemoryCache memoryCache)
            {
                var percentage = 1.0;
                memoryCache.Compact(percentage);
            }
        }
    }
}
