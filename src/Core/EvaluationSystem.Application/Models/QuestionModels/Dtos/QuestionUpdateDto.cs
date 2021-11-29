using EvaluationSystem.Domain.Enums;

namespace EvaluationSystem.Application.Models.QuestionModels.Dtos
{
    public class QuestionUpdateDto
    {
        public string Name { get; set; }
        public AnswersTypes? Type { get; set; }
    }
}
