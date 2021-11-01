using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Persistence.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private DataBase data;
        private IAnswerRepository _answerRepository;

        public QuestionRepository(IAnswerRepository repository)
        {
            data = new DataBase();
            _answerRepository = repository;
        }
        public Question GetAnswerById(int id)
        {
            Question question = data.questionData.FirstOrDefault(p => p.Id == id);
            question.Answers = _answerRepository.GetAllAnswerByQuestionId(id);

            return question;
        }
    }
}
