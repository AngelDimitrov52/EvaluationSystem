using AutoMapper;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Application.Services.HelpServices;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationSystem.Application.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IMapper _mapper;
        private readonly IModuleRepository _moduleRepository;
        private readonly IQuestionService _questionService;
        private readonly IQuestionRepository _questionRepository;

        public ModuleService(IMapper mapper, IModuleRepository repository, IQuestionService questionService, IQuestionRepository questionRepository)
        {
            _mapper = mapper;
            _moduleRepository = repository;
            _questionService = questionService;
            _questionRepository = questionRepository;
        }
        public List<ModuleGetDto> GetAll()
        {
            var modules = _moduleRepository.GetAll();

            return _mapper.Map<List<ModuleGetDto>>(modules);
        }
        public ModuleGetDto GetById(int id)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<ModuleTemplate>(id, _moduleRepository);

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
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<ModuleTemplate>(id, _moduleRepository);

            var module = _mapper.Map<ModuleTemplate>(model);
            module.Id = id;
            _moduleRepository.Update(module);

            return _mapper.Map<ModuleGetDto>(module);
        }
        public void Delete(int id)
        {
            _moduleRepository.DeleteModuleFromFormModuleTable(id);

            var questions = _moduleRepository.GetModuleQuestions(id);
            foreach (var question in questions)
            {
                _moduleRepository.DeleteQuestionFromModule(id, question.IdQuestion);
            }
            _moduleRepository.Delete(id);
        }

        public void AddQuestionToModule(int moduleId, int questionId, int position)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<ModuleTemplate>(moduleId, _moduleRepository);
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(questionId, _questionRepository);

            _moduleRepository.AddQuestionToModule(moduleId, questionId, position);
        }

        public void DeleteQuestionFromModule(int moduleId, int questionId)
        {
            _moduleRepository.DeleteQuestionFromModule(moduleId, questionId);
        }

        public ModuleWithQuestionsDto GetModuleWithQuestions(int moduleId)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<ModuleTemplate>(moduleId, _moduleRepository);

            var module = _moduleRepository.GetById(moduleId);
            var moduleWithQuestions = _mapper.Map<ModuleWithQuestionsDto>(module);
            moduleWithQuestions.Questions = new List<QuestionGetDto>();

            var questions = _moduleRepository.GetModuleQuestions(moduleId);
            moduleWithQuestions.Questions.AddRange(from question in questions
                                                   let result = _mapper.Map<QuestionGetDto>(_questionService.GetById(question.IdQuestion))
                                                   select result);

            return moduleWithQuestions;
        }

        public void EditQuestionPosition(int moduleId, int questionId, int position)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<ModuleTemplate>(moduleId, _moduleRepository);
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(questionId, _questionRepository);

            _moduleRepository.EditQuestionPosition(moduleId,questionId,position);
        }
    }
}

