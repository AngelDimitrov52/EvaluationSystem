using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections;
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
        private readonly IMemoryCache _memoryCache;

        public AnswerService(IMapper mapper, IAnswerRepository repository, IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _answerRepository = repository;
            _memoryCache = memoryCache;
        }

        public List<AnswerGetDto> GetAll(int questionId)
        {
            var answerCache = _memoryCache.Get($"allAnswer_{questionId}");
            if (answerCache != null)
            {
                return (List<AnswerGetDto>)answerCache;
            }

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
            IsEntityIsNull(answer);

            var answerGetDto = _mapper.Map<AnswerGetDto>(answer);
            _memoryCache.Set($"answer_{id}", answerGetDto);

            return answerGetDto;
        }
        public AnswerGetDto Create(int questionId, AnswerCreateDto model)
        {
            var answer = _mapper.Map<AnswerTemplate>(model);
            answer.IdQuestion = questionId;
            int answerId = _answerRepository.Create(answer);
            answer.Id = answerId;

            ClearMemoryCache();
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

            ClearMemoryCache();
            return _mapper.Map<AnswerGetDto>(answer);
        }
        public void Delete(int id)
        {
            ClearMemoryCache();
            _answerRepository.Delete(id);
        }


        private void IsEntityIsNull(AnswerTemplate entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Invalid answer id");
            }
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
