using Dapper;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Intefaces;
using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Persistence.Repositories
{
    class QuestionRepository : GenericRepository<QuestionTemplate>, IQuestionRepository
    {
        public QuestionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public List<QuestionRepositoryDto> GetQuestionById(int questionId)
        {
            string query = @$"SELECT q.Id AS QuestionId, q.[Name],q.IsReusable, q.[Type],a.Id AS AnswerId, a.AnswerText , a.Position, a.IsDefault
                                FROM AnswerTemplate AS a
                                RIGHT JOIN QuestionTemplate AS q ON q.Id = a.IdQuestion
                                WHERE q.Id = @Id";
            var result = Connection.Query<QuestionRepositoryDto>(query, new { Id = questionId }, Transaction);
            return (List<QuestionRepositoryDto>)result;
        }
        public List<ModuleQuestionTemplateDto> GetModuleQuestions(int moduleId)
        {
            string query = @"SELECT * FROM ModuleQuestion WHERE IdModule = @moduleId ORDER BY [Position] ASC";
            var result = Connection.Query<ModuleQuestionTemplateDto>(query, new { moduleId = moduleId }, Transaction);
            return (List<ModuleQuestionTemplateDto>)result;
        }
        public void AddQuestionToModule(int moduleId, int questionId, int position)
        {
            var query = "Insert Into ModuleQuestion (IdModule, IdQuestion, Position) Values(@IdModule, @IdQuestion, @Position)";
            Connection.Execute(query, new { IdModule = moduleId, IdQuestion = questionId, Position = position }, Transaction);
        }
        public void DeleteQuestionFromModule(int questionId)
        {
            string query = "Delete from ModuleQuestion where IdQuestion = @IdQuestion";
            Connection.Execute(query, new { IdQuestion = questionId }, Transaction);
        }
        public List<QuestionRepositoryDto> GetAllQuestionTemplates()
        {
            string query = @"SELECT q.Id AS QuestionId, q.[Name],q.IsReusable, q.[Type],a.Id AS AnswerId, a.AnswerText , a.Position, a.IsDefault
                                 FROM AnswerTemplate AS a
                                 RIGHT JOIN QuestionTemplate AS q ON q.Id = a.IdQuestion
                                 WHERE IsReusable = 1 ";
            var result = Connection.Query<QuestionRepositoryDto>(query, null, Transaction);
            return (List<QuestionRepositoryDto>)result;
        }
    }
}
