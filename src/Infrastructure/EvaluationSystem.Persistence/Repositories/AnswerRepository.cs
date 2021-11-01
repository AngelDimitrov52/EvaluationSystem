
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

        public List<АnswerEntity> GetAllAnswerByQuestionId(int id)
        {
            List<АnswerEntity> result = data.answerData.Where(p => p.QuestionId == id).ToList();

            return result;
        }
        public АnswerEntity GetAnswerById(int id)
        {
            АnswerEntity аnswer = data.answerData.FirstOrDefault(p => p.Id == id);

            return аnswer;
        }
    }
}
