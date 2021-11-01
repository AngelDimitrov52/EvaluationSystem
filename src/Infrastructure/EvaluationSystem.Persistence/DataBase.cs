using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Persistence
{
    public class DataBase
    {
        public List<QuestionEntity> questionData = new List<QuestionEntity>
        {
            new QuestionEntity{Id = 1, Title= "Title 1" , Answers = new List<АnswerEntity>()},
            new QuestionEntity{Id = 2, Title= "Title 2" , Answers = new List<АnswerEntity>()},
            new QuestionEntity{Id = 3, Title= "Title 3" , Answers = new List<АnswerEntity>()},
            new QuestionEntity{Id = 4, Title= "Title 4" , Answers = new List<АnswerEntity>()},
            new QuestionEntity{Id = 5, Title= "Title 5" , Answers = new List<АnswerEntity>()},
            new QuestionEntity{Id = 6, Title= "Title 6" , Answers = new List<АnswerEntity>()},
        };

        public List<АnswerEntity> answerData = new List<АnswerEntity>
        {
            new АnswerEntity{Id = 1, Title= "Answer 1", Type = "Radio Button" , QuestionId = 2},
            new АnswerEntity{Id = 2, Title= "Answer 2", Type = "Radio Button" , QuestionId = 2},
            new АnswerEntity{Id = 3, Title= "Answer 3", Type = "Check Boxes" , QuestionId = 1},
            new АnswerEntity{Id = 4, Title= "Answer 4", Type = "Check Boxes" , QuestionId = 1},
            new АnswerEntity{Id = 5, Title= "Answer 5", Type = "Check Boxes" , QuestionId = 5},
            new АnswerEntity{Id = 6, Title= "Answer 6", Type = "Numerical options" , QuestionId = 4},
            new АnswerEntity{Id = 7, Title= "Answer 7", Type = "Numerical options" , QuestionId = 4},
            new АnswerEntity{Id = 8, Title= "Answer 8", Type = "Numerical options" , QuestionId = 4},
            new АnswerEntity{Id = 9, Title= "Answer 9", Type = "Numerical options" , QuestionId = 6},
            new АnswerEntity{Id = 10, Title= "Answer 10", Type = "Radio Button" , QuestionId = 6},
            new АnswerEntity{Id = 11, Title= "Answer 11", Type = "Check Boxes" , QuestionId = 3},
            new АnswerEntity{Id = 12, Title= "Answer 12", Type = "Radio Button" , QuestionId = 3},
           
        };
    }
}
