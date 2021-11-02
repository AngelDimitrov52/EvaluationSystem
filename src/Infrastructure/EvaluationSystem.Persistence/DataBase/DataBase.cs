using EvaluationSystem.Domain.Entities;
using EvaluationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Persistence.DataBase
{
    public class DataBase : IDataBase

    {
        private List<Question> _questionData = new List<Question>
        {
            new Question{Id = 1, Title= "Title 1" , Answers = new List<Аnswer>()},
            new Question{Id = 2, Title= "Title 2" , Answers = new List<Аnswer>()},
            new Question{Id = 3, Title= "Title 3" , Answers = new List<Аnswer>()},
            new Question{Id = 4, Title= "Title 4" , Answers = new List<Аnswer>()},
            new Question{Id = 5, Title= "Title 5" , Answers = new List<Аnswer>()},
            new Question{Id = 6, Title= "Title 6" , Answers = new List<Аnswer>()},
        };

        private List<Аnswer> _answerData = new List<Аnswer>
        {
            new Аnswer{Id = 1, Title= "Answer 1", Type = BottonsTypes.CheckBoxes.ToString() , QuestionId = 2},
            new Аnswer{Id = 2, Title= "Answer 2", Type = BottonsTypes.CheckBoxes.ToString() , QuestionId = 2},
            new Аnswer{Id = 3, Title= "Answer 3", Type = BottonsTypes.CheckBoxes.ToString() , QuestionId = 1},
            new Аnswer{Id = 4, Title= "Answer 4", Type = BottonsTypes.NumericalOptions.ToString() , QuestionId = 1},
            new Аnswer{Id = 5, Title= "Answer 5", Type = BottonsTypes.NumericalOptions.ToString() , QuestionId = 5},
            new Аnswer{Id = 6, Title= "Answer 6", Type = BottonsTypes.NumericalOptions.ToString() , QuestionId = 4},
            new Аnswer{Id = 7, Title= "Answer 7", Type = BottonsTypes.RadioButtons.ToString() , QuestionId = 4},
            new Аnswer{Id = 8, Title= "Answer 8", Type = BottonsTypes.RadioButtons.ToString()  , QuestionId = 4},
            new Аnswer{Id = 9, Title= "Answer 9", Type = BottonsTypes.RadioButtons.ToString()  , QuestionId = 6},
            new Аnswer{Id = 10, Title= "Answer 10", Type = BottonsTypes.TextField.ToString()  , QuestionId = 6},
            new Аnswer{Id = 11, Title= "Answer 11", Type = BottonsTypes.TextField.ToString() , QuestionId = 3},
            new Аnswer{Id = 12, Title= "Answer 12", Type = BottonsTypes.TextField.ToString() , QuestionId = 3}
        };

        public List<Question> questionData => _questionData;

        public List<Аnswer> answerData => _answerData;
    }
}
