using EvaluationSystem.Application.Models.UserModels.Interface;

namespace EvaluationSystem.Application.Models.UserModels.Dtos
{
    public class CurrentUser : ICurrentUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
