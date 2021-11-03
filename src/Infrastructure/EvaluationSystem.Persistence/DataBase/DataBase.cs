﻿using EvaluationSystem.Domain.Entities;
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
            new Аnswer{Id = 1, Title= "Answer 1", QuestionId = 2},
            new Аnswer{Id = 2, Title= "Answer 2", QuestionId = 2},
            new Аnswer{Id = 3, Title= "Answer 3", QuestionId = 1},
            new Аnswer{Id = 4, Title= "Answer 4", QuestionId = 1},
            new Аnswer{Id = 5, Title= "Answer 5", QuestionId = 5},
            new Аnswer{Id = 6, Title= "Answer 6", QuestionId = 4},
            new Аnswer{Id = 7, Title= "Answer 7", QuestionId = 4},
            new Аnswer{Id = 8, Title= "Answer 8", QuestionId = 4},
            new Аnswer{Id = 9, Title= "Answer 9", QuestionId = 6},
            new Аnswer{Id = 10, Title= "Answer 10", QuestionId = 6},
            new Аnswer{Id = 11, Title= "Answer 11", QuestionId = 3},
            new Аnswer{Id = 12, Title= "Answer 12", QuestionId = 3}
        };

        public List<Question> QuestionData => _questionData;

        public List<Аnswer> AnswerData => _answerData;
    }
}
