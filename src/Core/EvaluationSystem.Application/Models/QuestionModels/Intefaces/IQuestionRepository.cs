using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.QuestionModels
{
    public interface IQuestionRepository : IGenericRepository<QuestionTemplate>
    {
        List<QuestionRepositoryDto> GetQuestionById(int id);
        List<QuestionRepositoryDto> GetAllQuestions(); 
    }
}
