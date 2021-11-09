using AutoMapper;
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

            List<QuestionDto> result = new List<QuestionDto>();

            foreach (var question in questions)
            {
                var isQuestionIsCreated = result.FirstOrDefault(x => x.QuestionId == question.QuestionId);
                if (isQuestionIsCreated == null)
                {
                    isQuestionIsCreated = new QuestionDto
                    {
                        QuestionId = question.QuestionId,
                        Name = question.Name,
                        Type = question.Type,
                        Answers = new List<AnswerGetDto>()
                    };
                    result.Add(isQuestionIsCreated);
                }
                if (question.AnswerId != 0)
                {
                    isQuestionIsCreated.Answers
                    .Add(new AnswerGetDto
                    {
                        AnswerId = question.AnswerId,
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
            var questionsResults = _questionRepository.GetById(id);

            QuestionGetDto questionGetDto = new QuestionGetDto
            {
                Name = questionsResults[0].Name,
                Type = questionsResults[0].Type,
                Answers = new List<AnswerGetDto>()
            };

            foreach (var question in questionsResults)
            {
                if (question.AnswerId != 0)
                {
                    questionGetDto.Answers
                    .Add(new AnswerGetDto
                    {
                        AnswerId = question.AnswerId,
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
            var question = _mapper.Map<Question>(model);
            question.QuestionId = id;
            _questionRepository.Update(question);
            return _mapper.Map<QuestionUpdateDto>(question); ;
        }

        public QuestionDto Create(QuestionCreateDto model)
        {
            var question = _mapper.Map<QuestionDbCreateDto>(model);
            int index = _questionRepository.AddNew(question);

            var questionWithAnswer = SetQuestion(index, model);
            return _mapper.Map<QuestionDto>(questionWithAnswer);
        }

        public void Delete(int id)
        {
            _answerRepository.DeleteWithQuestionId(id);
            _questionRepository.Delete(id);
        }

        private Question SetQuestion(int index, QuestionCreateDto model)
        {
            var questionWithAnswer = _mapper.Map<Question>(model);
            questionWithAnswer.QuestionId = index;

            foreach (var answer in questionWithAnswer.Answers)
            {
                var dto = _mapper.Map<AnswerCreateDbDto>(answer);
                dto.IdQuestion = index;
                int answerId = _answerRepository.AddNew(dto);
                answer.AnswerId = answerId;
            }
            return questionWithAnswer;
        }
    }
}
