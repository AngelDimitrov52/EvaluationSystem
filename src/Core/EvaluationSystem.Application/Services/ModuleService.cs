﻿using AutoMapper;
using EvaluationSystem.Application.Models.Exceptions;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IMapper _mapper;
        private readonly IModuleRepository _moduleRepository;
        private readonly IQuestionService _questionService;

        public ModuleService(IMapper mapper, IModuleRepository repository, IQuestionService questionService)
        {
            _mapper = mapper;
            _moduleRepository = repository;
            _questionService = questionService;
        }
        public List<ModuleGetDto> GetAll()
        {
            var modules = _moduleRepository.GetAll();

            return _mapper.Map<List<ModuleGetDto>>(modules);
        }
        public ModuleGetDto GetById(int id)
        {
            IsModuleExist(id);
            var module = _moduleRepository.GetById(id);

            return _mapper.Map<ModuleGetDto>(module);
        }
        public ModuleGetDto Create(ModuleCreateDto model)
        {
            var module = _mapper.Map<ModuleTemplate>(model);
            int moduleId = _moduleRepository.Create(module);
            module.Id = moduleId;

            return _mapper.Map<ModuleGetDto>(module);
        }
        public ModuleGetDto Update(int id, ModuleCreateDto model)
        {
            IsModuleExist(id);
            var module = _mapper.Map<ModuleTemplate>(model);
            module.Id = id;
            _moduleRepository.Update(module);

            return _mapper.Map<ModuleGetDto>(module);
        }
        public void Delete(int id)
        {
            var questions = _moduleRepository.GetModuleQuestions(id);
            foreach (var question in questions)
            {
                _moduleRepository.DeleteQuestionFromModule(id, question.IdQuestion);
            }
            _moduleRepository.Delete(id);
        }

        public void AddQuestionToModule(int moduleId, int questionId, int position)
        {
            IsModuleExist(moduleId);
            _questionService.IsQuestionExist(questionId);
            _moduleRepository.AddQuestionToModule(moduleId, questionId, position);
        }

        public void DeleteQuestionFromModule(int moduleId, int questionId)
        {
            _moduleRepository.DeleteQuestionFromModule(moduleId, questionId);
        }

        public ModuleWithQuestionsDto GetModuleWithQuestions(int moduleId)
        {
            IsModuleExist(moduleId);
            var module = _moduleRepository.GetById(moduleId);
            var moduleWithQuestions = _mapper.Map<ModuleWithQuestionsDto>(module);
            moduleWithQuestions.Questions = new List<QuestionGetDto>();

            var questions = _moduleRepository.GetModuleQuestions(moduleId);
            moduleWithQuestions.Questions.AddRange(from question in questions
                                                   let result = _mapper.Map<QuestionGetDto>(_questionService.GetById(question.IdQuestion))
                                                   select result);

            return moduleWithQuestions;
        }
        public void IsModuleExist(int moduleId)
        {
            var entity = _moduleRepository.GetById(moduleId);
            if (entity == null)
            {
                throw new HttpException($"Module with ID:{moduleId} doesn't exist!", HttpStatusCode.NotFound);
            }
        }
    }
}

