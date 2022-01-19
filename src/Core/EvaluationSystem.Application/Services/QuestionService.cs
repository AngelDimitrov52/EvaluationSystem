using AutoMapper;
using EvaluationSystem.Application.Models.Exceptions;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
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
    public class QuestionService : IQuestionService
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly IQuestionTemplateService _questionTemplateService;

        public QuestionService(IMapper mapper, IQuestionTemplateService questionTemplateService, IQuestionRepository questionRepository, IModuleRepository moduleRepository)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            _moduleRepository = moduleRepository;
            _questionTemplateService = questionTemplateService;
        }

        public List<QuestionGetDto> GetAll(int moduleId)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<ModuleTemplate>(moduleId, _moduleRepository);
            var result = new List<QuestionGetDto>();
            var questions = _questionRepository.GetModuleQuestions(moduleId);
            foreach (var question in questions)
            {
                var questionFromDB = GetById(moduleId, question.IdQuestion);
                result.Add(questionFromDB);
            }
            return result;
        }
        public QuestionGetDto GetById(int moduleId, int questionId)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<ModuleTemplate>(moduleId, _moduleRepository);
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(questionId, _questionRepository);
            var questionPosition = _questionRepository.GetModuleQuestions(moduleId).Where(x => x.IdModule == moduleId && x.IdQuestion == questionId).FirstOrDefault();
            ThrowExceptionWhenQustionIsNotInModule(moduleId, questionId, questionPosition);

            var question = _mapper.Map<QuestionGetDto>(_questionTemplateService.GetById(questionId));
            question.Position = questionPosition.Position;

            return question;
        }
        public QuestionGetDto Create(int moduleId, QuestionCreateDto model)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<ModuleTemplate>(moduleId, _moduleRepository);
            var isQuestionExist = _questionRepository.GetQuestionCustomByNameModuleIdAndQuestionId(model.Name, moduleId, 0);
            if (isQuestionExist != null)
            {
                throw new HttpException($"Question with this name already exists!", HttpStatusCode.BadRequest);
            }

            if (model.Answers != null)
            {
                if (model.Type == AnswersTypes.TextField && model.Answers.Count > 0)
                {
                    throw new HttpException("Invalid create answer in question with type TextField!", HttpStatusCode.BadRequest);
                }
            }

            if (model.IsTemplate == true)
            {
                _questionTemplateService.Create(_mapper.Map<QuestionTemplateCreateDto>(model));
            }

            var question = _mapper.Map<QuestionTemplate>(model);
            question.IsReusable = false;
            question.DateOfCreation = DateTime.Now;

            ThrowExceptionHeplService.ThrowExceptionWhenAnsersIsNotNumericalOptions(question.Type, question.Answers);

            int index = _questionRepository.Create(question);
            var questionWithAnswer = _questionTemplateService.CreateQuestionAnswers(index, question);
            _questionRepository.AddQuestionToModule(moduleId, questionWithAnswer.Id, model.Position);

            var result = _mapper.Map<QuestionGetDto>(questionWithAnswer);
            result.Position = model.Position;
            return result;
        }

        public QuestionUpdateDto Update(int moduleId, int questionId, QuestionUpdateDto model)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<ModuleTemplate>(moduleId, _moduleRepository);
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(questionId, _questionRepository);
            var isQuestionExist = _questionRepository.GetQuestionCustomByNameModuleIdAndQuestionId(model.Name, moduleId, questionId);
            if (isQuestionExist != null)
            {
                throw new HttpException($"Question with this name already exists!", HttpStatusCode.BadRequest);
            }
            var questionPosition = _questionRepository.GetModuleQuestions(moduleId).Where(x => x.IdModule == moduleId && x.IdQuestion == questionId).FirstOrDefault();
            ThrowExceptionWhenQustionIsNotInModule(moduleId, questionId, questionPosition);

            var questionFromDB = _questionRepository.GetById(questionId);
            var question = _mapper.Map<QuestionTemplate>(model);
            question.Id = questionId;
            question.Type = questionFromDB.Type;
            question.DateOfCreation = questionFromDB.DateOfCreation;

            _questionRepository.Update(question);
            _questionRepository.UpdateQuestionPosition(moduleId, questionId, model.Position);

            return model;
        }

        public void Delete(int questionId)
        {
            _questionTemplateService.Delete(questionId);
        }
        private void ThrowExceptionWhenQustionIsNotInModule(int moduleId, int questionId, ModuleQuestionTemplateDto dto)
        {
            if (dto == null)
            {
                throw new HttpException($"Question with ID:{questionId} doesn't exist in module with ID:{moduleId}!", HttpStatusCode.BadRequest);
            }
        }
    }
}