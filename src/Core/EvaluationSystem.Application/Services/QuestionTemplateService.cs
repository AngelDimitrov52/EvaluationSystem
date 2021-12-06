using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Application.Models.QuestionModels.Intefaces;
using EvaluationSystem.Application.Services.HelpServices;
using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var question = _mapper.Map<QuestionTemplate>(model);
            question.IsReusable = true;
            question.DateOfCreation = DateTime.Now;
            ThrowExceptionHeplService.ThrowExceptionWhenAnsersIsNotNumericalOptions(question.Type, question.Answers);

            int index = _questionRepository.Create(question);
            var questionWithAnswer = CreateQuestionAnswers(index, question);
            return _mapper.Map<QuestionTemplateGetDto>(questionWithAnswer);
        }
        public QuestionTemplateUpdateDto Update(int questionId, QuestionTemplateUpdateDto model)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(questionId, _questionRepository);

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
                answer.IdQuestion = questionId;
                int answerId = _answerRepository.Create(answer);
                answer.Id = answerId;
            }
            return model;
        }
    }
}
