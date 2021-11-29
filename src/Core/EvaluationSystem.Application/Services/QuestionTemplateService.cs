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
using Microsoft.Extensions.Caching.Memory;
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

        public QuestionTemplateService(IAnswerRepository answerRepository, IMapper mapper, IQuestionRepository questionRepository)
        {
            _mapper = mapper;
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
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
        public QuestionTemplateGetDto GetById(int id)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(id, _questionRepository);

            var questionsResults = _questionRepository.GetQuestionById(id);

            if (questionsResults[0].IsReusable == false)
            {
                throw new HttpException("Question is not reusable!", HttpStatusCode.BadRequest);
            }

            var questionGetDto = new QuestionTemplateGetDto
            {
                Id = questionsResults[0].QuestionId,
                Name = questionsResults[0].Name,
                Type = questionsResults[0].Type,
                Answers = new List<AnswerGetDto>()
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
        public QuestionGetDto Create(QuestionCreateDto model)
        {
            var question = _mapper.Map<QuestionTemplate>(model);
            question.IsReusable = true;

            if (question.Type == AnswersTypes.NumericalOptions)
            {
                ThrowExceptionHeplService.ThrowExceptionWhenAnsersIsNotNumericalOptions(question.Answers);
            }

            int index = _questionRepository.Create(question);
            var questionWithAnswer = CreateQuestionAnsers(index, question);
            return _mapper.Map<QuestionGetDto>(questionWithAnswer);
        }
        public QuestionUpdateDto Update(int id, QuestionUpdateDto model)
        {
            ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(id, _questionRepository);

            var question = _mapper.Map<QuestionTemplate>(model);
            question.IsReusable = true;
            question.Id = id;
            _questionRepository.Update(question);

            return _mapper.Map<QuestionUpdateDto>(question);
        }

        public void Delete(int id)
        {
            _answerRepository.DeleteWithQuestionId(id);
            _questionRepository.Delete(id);
        }
        private QuestionTemplate CreateQuestionAnsers(int index, QuestionTemplate model)
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
