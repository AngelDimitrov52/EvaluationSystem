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
        List<QuestionRepositoryDto> GetById(int id);
        List<QuestionRepositoryDto> GetAll();
        int AddNew(QuestionDbCreateDto model);
        void Update(QuestionTemplate model);
    }
}
