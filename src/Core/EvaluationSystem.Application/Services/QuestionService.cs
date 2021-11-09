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
            var questions = GetAllQuestionsWithAnswers();
            return _mapper.Map<List<QuestionDto>>(questions);
        }

        public QuestionGetDto GetById(int id)
        {
            var question = _questionRepository.GetById(id);
            question.Answers = _answerRepository.GetAll(id);
            return _mapper.Map<QuestionGetDto>(question);
        }

        public QuestionUpdateDto Update(int id, QuestionUpdateDto model)
        {
            var question = _mapper.Map<Question>(model);
            question.Id = id;
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

        private List<Question> GetAllQuestionsWithAnswers()
        {
            var questions = _questionRepository.GetAll();
            foreach (var question in questions)
            {
                question.Answers = _answerRepository.GetAll(question.Id);
            }
            return questions;
        }
        private Question SetQuestion(int index, QuestionCreateDto model)
        {
            var questionWithAnswer = _mapper.Map<Question>(model);
            questionWithAnswer.Id = index;

            foreach (var answer in questionWithAnswer.Answers)
            {
                var dto = _mapper.Map<AnswerCreateDbDto>(answer);
                dto.IdQuestion = index;
                int answerId = _answerRepository.AddNew(dto);
                answer.Id = answerId;
            }
            return questionWithAnswer;
        }

    }
}
