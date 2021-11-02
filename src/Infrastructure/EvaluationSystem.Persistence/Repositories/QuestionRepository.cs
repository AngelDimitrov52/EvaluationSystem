using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Domain.Entities;
using EvaluationSystem.Persistence.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Persistence.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {

        private IAnswerRepository _answerRepository;
        private IDataBase data;

        public QuestionRepository(IAnswerRepository repository, IDataBase dataBase)
        {
            data = dataBase;
            _answerRepository = repository;
        }
        public List<Question> GetAll()
        {
            List<Question> questions = data.questionData;
            foreach (var question in questions)
            {
                question.Answers = _answerRepository.GetAllAnswerByQuestionId(question.Id);
            }
            return questions;
        }
        public Question GetById(int id)
        {
            Question question = data.questionData.FirstOrDefault(p => p.Id == id);
            question.Answers = _answerRepository.GetAllAnswerByQuestionId(id);
            return question;
        }
        public Question AddNew(Question model)
        {
            data.questionData.Add(model);
            return model;
        }

        public Question Delete(int id)
        {
            Question question = data.questionData.FirstOrDefault(p => p.Id == id);
            data.questionData.Remove(question);
            return question;
        }
        public Question Update(Question model)
        {
            int index = data.questionData.FindIndex(p => p.Id == model.Id);
            data.questionData[index] = model;
            return model;
        }
    }
}
