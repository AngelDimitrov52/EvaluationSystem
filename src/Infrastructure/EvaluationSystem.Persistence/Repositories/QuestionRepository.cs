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
        private readonly IDataBase _data;

        public QuestionRepository(IDataBase dataBase)
        {
            _data = dataBase;
        }
        public List<Question> GetAll() => _data.QuestionData;
        public Question GetById(int id)
        {
            return _data.QuestionData.FirstOrDefault(p => p.Id == id);
        }
        public Question AddNew(Question model)
        {
            GiveModelId(model);
            _data.QuestionData.Add(model);
            return model;
        }

        public void Delete(int id)
        {
            var question = _data.QuestionData.FirstOrDefault(p => p.Id == id);
            _data.QuestionData.Remove(question);

        }
        public Question Update(Question model)
        {
            int index = _data.QuestionData.FindIndex(p => p.Id == model.Id);
            _data.QuestionData[index].Title = model.Title;
            _data.QuestionData[index].Type = model.Type;
            return model;
        }

        private void GiveModelId(Question model)
        {
            var questionId = _data.QuestionData.Count();
            model.Id = questionId + 1;
            for (int i = 1; i <= model.Answers.Count; i++)
            {
                model.Answers[i-1].Id = _data.AnswerData.Count + 1;
                model.Answers[i - 1].IdQuestion = questionId + 1;
                _data.AnswerData.Add(model.Answers[i - 1]);
            }
        }
    }
}
