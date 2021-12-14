namespace EvaluationSystem.Application.Models.UserModels.Interface
{
    public interface ICurrentUser
    {
         int Id { get; set; }
        string Email { get; set; }
        string Name { get; set; }
    }
}
