using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Application.Models.Exceptions;
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
    public class QuestionService : IQuestionService
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;

        public HttpStatusCode BadRequest { get; private set; }

        public QuestionService(IAnswerRepository answerRepository, IMapper mapper, IQuestionRepository repository)
        {
            _mapper = mapper;
            _questionRepository = repository;
            _answerRepository = answerRepository;
        }

        public List<QuestionGetDto> GetAll()
        {
            var questions = _questionRepository.GetAllQuestions();

            List<QuestionGetDto> result = new List<QuestionGetDto>();

            foreach (var question in questions)
            {
                var isQuestionIsCreated = result.FirstOrDefault(x => x.Id == question.QuestionId);
                if (isQuestionIsCreated == null)
                {
                    isQuestionIsCreated = new QuestionGetDto
                    {
                        Id = question.QuestionId,
                        IsReusable = question.IsReusable,
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

        public QuestionGetDto GetById(int id)
        {
            var questionsResults = _questionRepository.GetQuestionById(id);

            QuestionGetDto questionGetDto = new QuestionGetDto
            {
                Id = questionsResults[0].QuestionId,
                IsReusable = questionsResults[0].IsReusable,
                Name = questionsResults[0].Name,
                Type = questionsResults[0].Type,
                Answers = new List<AnswerGetDto>()
            };
            foreach (var question in questionsResults)
            {
                if (question.AnswerId != 0)
                {
                    questionGetDto.Answers.Add(new AnswerGetDto
                    {
                        Id = question.AnswerId,
                        Position = question.Position,
                        AnswerText = question.AnswerText,
                        IsDefault = question.IsDefault
                    });
                }
            }
            return questionGetDto;
        }

        public QuestionUpdateDto Update(int id, QuestionUpdateDto model)
        {
            var entity = _questionRepository.GetById(id);
            if (entity == null)
            {
                throw new ArgumentException("Invalid question id");
            }

            var question = _mapper.Map<QuestionTemplate>(model);
            question.Id = id;
            _questionRepository.Update(question);
            return _mapper.Map<QuestionUpdateDto>(question); ;
        }

        public QuestionGetDto Create(QuestionCreateDto model)
        {
            var question = _mapper.Map<QuestionTemplate>(model);
            int index = _questionRepository.Create(question);

            var questionWithAnswer = CreateQuestionAnsers(index, question);
            return _mapper.Map<QuestionGetDto>(questionWithAnswer);
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
