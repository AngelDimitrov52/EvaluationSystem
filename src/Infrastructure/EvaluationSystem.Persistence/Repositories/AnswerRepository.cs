
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
        private IDataBase data;

        public AnswerRepository(IDataBase dataBase)
        {
            data = dataBase;
        }

        public Аnswer AddNew(Аnswer model)
        {
            data.answerData.Add(model);
            return model;
        }

        public Аnswer Delete(int id)
        {
            Аnswer аnswer = data.answerData.FirstOrDefault(p => p.Id == id);
            data.answerData.Remove(аnswer);
            return аnswer;
        }

        public List<Аnswer> GetAll()
        {
            List<Аnswer> result = data.answerData;
            return result;
        }
        public List<Аnswer> GetAllAnswerByQuestionId(int id)
        {
            List<Аnswer> result = data.answerData.Where(p => p.QuestionId == id).ToList();
            return result;
        }
        public Аnswer GetById(int id)
        {
            Аnswer аnswer = data.answerData.FirstOrDefault(p => p.Id == id);
            return аnswer;
        }

        public Аnswer Update(Аnswer model)
        {
            int index = data.answerData.FindIndex(p => p.Id == model.Id);
            data.answerData[index] = model;
            return model;
        }
    }
}
