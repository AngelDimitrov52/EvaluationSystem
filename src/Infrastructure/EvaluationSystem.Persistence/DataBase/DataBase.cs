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
            new Question{Id = 1, Title= "Title 1" , Type = AnswersTypes.CheckBoxes, Answers = new List<Аnswer>()},
            new Question{Id = 2, Title= "Title 2" ,Type = AnswersTypes.CheckBoxes, Answers = new List<Аnswer>()},
            new Question{Id = 3, Title= "Title 3" ,Type = AnswersTypes.NumericalOptions, Answers = new List<Аnswer>()},
            new Question{Id = 4, Title= "Title 4" ,Type = AnswersTypes.NumericalOptions, Answers = new List<Аnswer>()},
            new Question{Id = 5, Title= "Title 5" ,Type = AnswersTypes.RadioButtons, Answers = new List<Аnswer>()},
            new Question{Id = 6, Title= "Title 6" ,Type = AnswersTypes.TextField, Answers = new List<Аnswer>()},
        };

        private List<Аnswer> _answerData = new List<Аnswer>
        {
            new Аnswer{Id = 1, AnswerText= "Answer 1", IdQuestion = 2},
            new Аnswer{Id = 2, AnswerText= "Answer 2", IdQuestion = 2},
            new Аnswer{Id = 3, AnswerText= "Answer 3", IdQuestion = 1},
            new Аnswer{Id = 4, AnswerText= "Answer 4", IdQuestion = 1},
            new Аnswer{Id = 5, AnswerText= "Answer 5", IdQuestion = 5},
            new Аnswer{Id = 6, AnswerText= "Answer 6", IdQuestion = 4},
            new Аnswer{Id = 7, AnswerText= "Answer 7", IdQuestion = 4},
            new Аnswer{Id = 8, AnswerText= "Answer 8", IdQuestion = 4},
            new Аnswer{Id = 9, AnswerText= "Answer 9", IdQuestion = 6},
            new Аnswer{Id = 10, AnswerText= "Answer 10", IdQuestion = 6},
            new Аnswer{Id = 11, AnswerText= "Answer 11", IdQuestion = 3},
            new Аnswer{Id = 12, AnswerText= "Answer 12", IdQuestion = 3}
        };

        public List<Question> QuestionData => _questionData;

        public List<Аnswer> AnswerData => _answerData;
    }
}
