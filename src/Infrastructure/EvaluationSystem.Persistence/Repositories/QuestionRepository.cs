using Dapper;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Intefaces;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Persistence.Repositories
{
    class QuestionRepository : GenericRepository<QuestionTemplate>, IQuestionRepository
    {
        public QuestionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public List<QuestionRepositoryDto> GetAllQuestionTemplates()
        {
            string query = @"SELECT q.Id AS QuestionId, q.[Name],q.IsReusable, q.[Type],q.DateOfCreation ,a.Id AS AnswerId, a.AnswerText , a.Position, a.IsDefault
                                 FROM AnswerTemplate AS a
                                 RIGHT JOIN QuestionTemplate AS q ON q.Id = a.IdQuestion
                                 WHERE IsReusable = 1";
            var result = Connection.Query<QuestionRepositoryDto>(query, null, Transaction);
            return (List<QuestionRepositoryDto>)result;
        }
        public List<ModuleQuestionTemplateDto> GetModuleQuestions(int moduleId)
        {
            string query = @"SELECT * FROM ModuleQuestion WHERE IdModule = @moduleId ORDER BY [Position] ASC";
            var result = Connection.Query<ModuleQuestionTemplateDto>(query, new { moduleId = moduleId }, Transaction);
            return (List<ModuleQuestionTemplateDto>)result;
        }
        public QuestionTemplate GetQuestionTemplateByNameAndId(string name, int questoinId)
        {
            string query = @"SELECT * FROM [EvaluationSystem].[dbo].QuestionTemplate WHERE [Name] = @QuestionName AND IsReusable = 1 And Id != @QuestoinId";
            var result = Connection.QueryFirstOrDefault<QuestionTemplate>(query, new { QuestionName = name, QuestoinId = questoinId }, Transaction);
            return result;
        }
        public QuestionTemplate GetQuestionCustomByNameModuleIdAndQuestionId(string name, int moduleId, int questoinId)
        {
            string query = @"SELECT qt.Id, qt.[Name], qt.DateOfCreation , qt.[Type] , qt.IsReusable
                             FROM QuestionTemplate AS qt
                             RIGHT JOIN ModuleQuestion AS mq ON mq.IdQuestion = qt.Id  
                             WHERE qt.[Name] = @QuestionName AND mq.IdModule = @ModuleId AND qt.Id != @QuestoinId;";
            var result = Connection.QueryFirstOrDefault<QuestionTemplate>(query, new { QuestionName = name, QuestoinId = questoinId, ModuleId = moduleId}, Transaction);
            return result;
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
        public void UpdateQuestionPosition(int moduleId, int questionId, int position)
        {
            string query = "UPDATE ModuleQuestion SET IdModule = @IdModule, IdQuestion = @IdQuestion, Position =@Position WHERE IdModule = @IdModule AND IdQuestion = @IdQuestion;";
            Connection.Execute(query, new { IdModule = moduleId, IdQuestion = questionId, Position = position }, Transaction);
        }
    }
}
