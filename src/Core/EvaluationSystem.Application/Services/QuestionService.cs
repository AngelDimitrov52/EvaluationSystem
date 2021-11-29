﻿using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Application.Models.QuestionModels.Intefaces;
using EvaluationSystem.Application.Services.HelpServices;
using EvaluationSystem.Domain.Entities;
using EvaluationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IModuleRepository _moduleRepository;
        public QuestionService(IMapper mapper, IAnswerRepository answerRepository, IQuestionRepository questionRepository, IModuleRepository moduleRepository)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _moduleRepository = moduleRepository;
        }

        public List<QuestionGetDto> GetAll(int moduleId)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<ModuleTemplate>(moduleId, _moduleRepository);
            var result = new List<QuestionGetDto>();
            var questions = _questionRepository.GetModuleQuestions(moduleId);
            foreach (var question in questions)
            {
                var questionFromDB = GetById(question.IdQuestion);
                questionFromDB.Position = question.Position;
                result.Add(questionFromDB);
            }
            return result;
        }
        public QuestionGetDto GetById(int questionId)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(questionId, _questionRepository);

            var questionsResults = _questionRepository.GetQuestionById(questionId);

            QuestionGetDto questionGetDto = new QuestionGetDto
            {
                Id = questionsResults[0].QuestionId,
                Name = questionsResults[0].Name,
                Type = questionsResults[0].Type,
                Answers = new List<AnswerGetDto>(),
            };
            questionGetDto.Answers.AddRange(from question in questionsResults
                                            where question.AnswerId != 0
                                            select new AnswerGetDto
                                            {
                                                Id = question.AnswerId,
                                                Position = question.Position,
                                                AnswerText = question.AnswerText,
                                                IsDefault = question.IsDefault
                                            });
            return questionGetDto;
        }
        public QuestionGetDto Create(int moduleId, QuestionCreateDto model)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<ModuleTemplate>(moduleId, _moduleRepository);
            var question = _mapper.Map<QuestionTemplate>(model);
            question.IsReusable = false;

            if (question.Type == AnswersTypes.NumericalOptions)
            {
                ThrowExceptionHeplService.ThrowExceptionWhenAnsersIsNotNumericalOptions(question.Answers);
            }

            int index = _questionRepository.Create(question);
            var questionWithAnswer = CreateQuestionAnsers(index, question);
            _questionRepository.AddQuestionToModule(moduleId, questionWithAnswer.Id, model.Position);
            return _mapper.Map<QuestionGetDto>(questionWithAnswer);
        }

        public QuestionUpdateDto Update(int questionId, QuestionUpdateDto model)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(questionId, _questionRepository);

            var question = _mapper.Map<QuestionTemplate>(model);
            question.IsReusable = false;
            question.Id = questionId;
            _questionRepository.Update(question);

            return _mapper.Map<QuestionUpdateDto>(question);
        }

        public void Delete(int questionId)
        {
            _questionRepository.DeleteQuestionFromModule(questionId);
            _answerRepository.DeleteWithQuestionId(questionId);
            _questionRepository.Delete(questionId);
        }
        public QuestionTemplate CreateQuestionAnsers(int index, QuestionTemplate model)
        {
            model.Id = index;
            foreach (var answer in model.Answers)
            {
                answer.IdQuestion = index;
                int answerId = _answerRepository.Create(answer);
                answer.Id = answerId;
            }
            return model;
        }
    }
}

