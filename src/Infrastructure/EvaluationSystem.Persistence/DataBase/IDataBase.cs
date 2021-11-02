using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Persistence.DataBase
{
    public interface IDataBase
    {
        List<Question> questionData => null;
        List<Аnswer> answerData => null;
    }
}
