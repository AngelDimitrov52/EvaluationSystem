
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Persistence.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private DataBase data = new DataBase();

        public List<Аnswer> GetAllAnswerByQuestionId(int id)
        {
            List<Аnswer> result = data.answerData.Where(p => p.QuestionId == id).ToList();

            return result;
        }
        public Аnswer GetAnswerById(int id)
        {
            Аnswer аnswer = data.answerData.FirstOrDefault(p => p.Id == id);

            return аnswer;
        }
    }
}
