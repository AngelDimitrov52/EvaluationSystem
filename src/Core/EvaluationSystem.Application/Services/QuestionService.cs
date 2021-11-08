﻿using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Application.Models.Dtos;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Domain.Entities;
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
        public QuestionService(IAnswerRepository answerRepository, IMapper mapper, IQuestionRepository repository)
        {
            _mapper = mapper;
            _questionRepository = repository;
            _answerRepository = answerRepository;
        }
        public List<QuestionDto> GetAll()
        {
            var questions = _questionRepository.GetAll();
            foreach (var question in questions)
            {
                question.Answers = _answerRepository.GetAll(question.Id);
            }
            return _mapper.Map<List<QuestionDto>>(questions);
        }
        public QuestionGetDto GetById(int id)
        {
            var question = GetQuestion(id);
            return _mapper.Map<QuestionGetDto>(question);
        }
        public QuestionUpdateDto Update(int id, QuestionUpdateDto model)
        {
            var question = _mapper.Map<Question>(model);
            question.Id = id;
            _questionRepository.Update(question);

            return _mapper.Map<QuestionUpdateDto>(question); ;
        }
        public QuestionCreateDto Create(QuestionCreateDto model)
        {
            var question = _mapper.Map<QuestionDbCreateDto>(model);
            int index = _questionRepository.AddNew(question);

            var questionWithAnswer = _mapper.Map<Question>(model);

            foreach (var answer in questionWithAnswer.Answers)
            {
                var dto = _mapper.Map<AnswerCreateDbDto>(answer);
                dto.IdQuestion = index;
                _answerRepository.AddNew(dto);
            }
            return _mapper.Map<QuestionCreateDto>(questionWithAnswer);
        }
        public void Delete(int id)
        {
            var question = GetQuestion(id);
            foreach (var answer in question.Answers)
            {
                _answerRepository.Delete(answer.Id);
            }
            _questionRepository.Delete(id);
        }
        private Question GetQuestion(int id)
        {
            var question = _questionRepository.GetById(id);
            question.Answers = _answerRepository.GetAll(id);
            return question;
        }
    }
}
