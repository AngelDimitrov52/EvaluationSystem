using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Application.Models.Exceptions;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Application.Models.QuestionModels.Intefaces;
using EvaluationSystem.Application.Services.HelpServices;
using EvaluationSystem.Domain.Entities;
using EvaluationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace EvaluationSystem.Application.Services
{
    public class QuestionTemplateService : IQuestionTemplateService
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IAnswerService _answerService;

        public QuestionTemplateService(IAnswerRepository answerRepository, IMapper mapper, IQuestionRepository questionRepository, IAnswerService answerService)
        {
            _mapper = mapper;
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
            _answerService = answerService;
        }
        public List<QuestionTemplateGetDto> GetAll()
        {
            var questions = _questionRepository.GetAllQuestionTemplates();

            List<QuestionTemplateGetDto> result = new List<QuestionTemplateGetDto>();

            foreach (var question in questions)
            {
                var isQuestionIsCreated = result.FirstOrDefault(x => x.Id == question.QuestionId);
                if (isQuestionIsCreated == null)
                {
                    isQuestionIsCreated = new QuestionTemplateGetDto
                    {
                        Id = question.QuestionId,
                        Name = question.Name,
                        Type = question.Type,
                        DateOfCreation = question.DateOfCreation,
                        Answers = new List<AnswerGetDto>()
                    };
                    result.Add(isQuestionIsCreated);
                }
                if (question.AnswerId != 0)
                {
                    isQuestionIsCreated.Answers.Add(new AnswerGetDto
                    {
                        Id = question.AnswerId,
                        Position = question.Position,
                        AnswerText = question.AnswerText,
                        IsDefault = question.IsDefault
                    });
                }
            }
            return result;
        }
        public QuestionTemplateGetDto GetById(int questionId)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(questionId, _questionRepository);

            var questionResult = _mapper.Map<QuestionTemplateGetDto>(_questionRepository.GetById(questionId));
            questionResult.Answers = _answerService.GetAll(questionId);
            return questionResult;
        }
        public QuestionTemplateGetDto Create(QuestionTemplateCreateDto model)
        {
            var isQuestionExist = _questionRepository.GetQuestionTemplateByNameAndId(model.Name, 0);
            if (isQuestionExist != null)
            {
                throw new HttpException($"Question template with this name already exists!", HttpStatusCode.BadRequest);
            }

            var question = _mapper.Map<QuestionTemplate>(model);
            question.IsReusable = true;
            question.DateOfCreation = DateTime.Now;
            ThrowExceptionHeplService.ThrowExceptionWhenAnsersIsNotNumericalOptions(question.Type, question.Answers);

            int questionId = _questionRepository.Create(question);
            if (question.Type == AnswersTypes.TextField && question.Answers.Count > 0)
            {
                throw new HttpException("Invalid create answer in question with type TextField!", HttpStatusCode.BadRequest);
            }

            var questionWithAnswer = CreateQuestionAnswers(questionId, question);
            return _mapper.Map<QuestionTemplateGetDto>(questionWithAnswer);
        }
        public QuestionTemplateUpdateDto Update(int questionId, QuestionTemplateUpdateDto model)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(questionId, _questionRepository);
            var isQuestionExist = _questionRepository.GetQuestionTemplateByNameAndId(model.Name, questionId);
            if (isQuestionExist != null)
            {
                throw new HttpException($"Question template with this name already exists!", HttpStatusCode.BadRequest);
            }

            var questionFromDB = _questionRepository.GetById(questionId);
            var question = _mapper.Map<QuestionTemplate>(model);
            question.IsReusable = true;
            question.Id = questionId;
            question.Type = questionFromDB.Type;
            question.DateOfCreation = questionFromDB.DateOfCreation;

            _questionRepository.Update(question);
            return model;
        }

        public void Delete(int questionId)
        {
            _questionRepository.DeleteQuestionFromModule(questionId);
            _answerRepository.DeleteWithQuestionId(questionId);
            _questionRepository.Delete(questionId);
        }
        public QuestionTemplate CreateQuestionAnswers(int questionId, QuestionTemplate model)
        {
            model.Id = questionId;
            foreach (var answer in model.Answers)
            {
                var isAnswerExists = _answerService.GetAll(questionId).FirstOrDefault(x => x.AnswerText == answer.AnswerText);
                if (isAnswerExists != null)
                {
                    throw new HttpException($"Answer with this name already exists in this Question!", HttpStatusCode.BadRequest);
                }
                answer.IdQuestion = questionId;
                int answerId = _answerRepository.Create(answer);
                answer.Id = answerId;
            }
            return model;
        }
    }
}
