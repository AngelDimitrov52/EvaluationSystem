
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Domain.Entities;
using EvaluationSystem.Persistence.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Persistence.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly IDataBase _data;

        public AnswerRepository(IDataBase dataBase)
        {
            _data = dataBase;
        }

        public Аnswer AddNew(Аnswer model)
        {
            GiveModelId(model);
            _data.AnswerData.Add(model);
            return model;
        }

        public void Delete(int id)
        {
            var аnswer = _data.AnswerData.FirstOrDefault(p => p.Id == id);
            _data.AnswerData.Remove(аnswer);
        }

        public List<Аnswer> GetAll()
        {
            return _data.AnswerData;
        }
        public List<Аnswer> GetAllAnswerByQuestionId(int id)
        {
            return _data.AnswerData.Where(p => p.QuestionId == id).ToList();
        }
        public Аnswer GetById(int questionId, int id)
        {
            return _data.AnswerData.FirstOrDefault(p => p.Id == id && p.QuestionId == questionId);
        }

        public Аnswer Update(Аnswer model)
        {
            int index = _data.AnswerData.FindIndex(p => p.Id == model.Id);
            _data.AnswerData[index] = model;
            return model;
        }

        private void GiveModelId(Аnswer model)
        {
            model.Id = _data.AnswerData.Count + 1;
        }
    }
}
