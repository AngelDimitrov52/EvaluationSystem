using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Application.Models.Exceptions;
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
using System.Text;
using System.Threading.Tasks;

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

            var question = _mapper.Map<QuestionGetDto>(_questionTemplateService.GetById(questionId));
            var questionPosition = _questionRepository.GetModuleQuestions(moduleId).Where(x => x.IdModule == moduleId && x.IdQuestion == questionId).FirstOrDefault();
            if (questionPosition == null)
            {
                throw new HttpException($"Question with ID:{questionId} doesn't exist in module with ID:{moduleId}!", HttpStatusCode.BadRequest);
            }
            question.Position = questionPosition.Position;

            return question;
        }
        public QuestionGetDto Create(int moduleId, QuestionCreateDto model)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<ModuleTemplate>(moduleId, _moduleRepository);
            var question = _mapper.Map<QuestionTemplate>(model);
            question.IsReusable = false;

            ThrowExceptionHeplService.ThrowExceptionWhenAnsersIsNotNumericalOptions(question.Type, question.Answers);

            int index = _questionRepository.Create(question);
            var questionWithAnswer = _questionTemplateService.CreateQuestionAnswers(index, question);
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
            _questionTemplateService.Delete(questionId);
        }
    }
}

