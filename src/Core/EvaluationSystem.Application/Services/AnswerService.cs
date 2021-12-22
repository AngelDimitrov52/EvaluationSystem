using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Application.Models.Exceptions;
using EvaluationSystem.Application.Models.QuestionModels.Intefaces;
using EvaluationSystem.Application.Services.HelpServices;
using EvaluationSystem.Domain.Entities;
using EvaluationSystem.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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
            var isAnswerExists = GetAll(questionId).FirstOrDefault(x => x.AnswerText == model.AnswerText);
            if (isAnswerExists != null)
            {
                throw new HttpException($"Answer with this name already exists in this Question!", HttpStatusCode.BadRequest);
            }

            var answer = _mapper.Map<AnswerTemplate>(model);
            var question = _questionRepository.GetById(questionId);
            if (question.Type == AnswersTypes.TextField)
            {
                throw new HttpException("Invalid create answer in question with type TextField!", HttpStatusCode.BadRequest);
            }
            if (question.Type == AnswersTypes.NumericalOptions)
            {
                int numericValue;
                bool isInt = int.TryParse(answer.AnswerText, out numericValue);
                if (isInt == false)
                {
                    throw new HttpException("Answer is not NumericalOptions!", HttpStatusCode.BadRequest);
                }
            }
            answer.IdQuestion = questionId;
            int answerId = _answerRepository.Create(answer);
            answer.Id = answerId;

            return _mapper.Map<AnswerGetDto>(answer);
        }

        public AnswerGetDto Update(int questionId, int answerId, AnswerCreateDto model)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(questionId, _questionRepository);
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<AnswerTemplate>(answerId, _answerRepository);
            var isAnswerExists = GetAll(questionId).FirstOrDefault(x => x.AnswerText == model.AnswerText && x.Id != answerId);
            if (isAnswerExists != null)
            {
                throw new HttpException($"Answer with this name already exists in this Question!", HttpStatusCode.BadRequest);
            }

            var answer = _mapper.Map<AnswerTemplate>(model);

            answer.IdQuestion = questionId;
            answer.Id = answerId;
            _answerRepository.Update(answer);

            return _mapper.Map<AnswerGetDto>(answer);
        }
        public void Delete(int id)
        {
            _answerRepository.Delete(id);
        }
    }
}
