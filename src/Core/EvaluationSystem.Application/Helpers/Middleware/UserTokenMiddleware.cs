using EvaluationSystem.Application.Models.UserModels.Interface;
using EvaluationSystem.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Helpers.Middleware
{
    public class UserTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public UserTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserRepository userRepository, ICurrentUser currentUser)
        {
            var userEmail = context.User.Claims.FirstOrDefault(c => c.Type == "preferred_username").Value;

            var user = userRepository.GetUserByEmail(userEmail);
            if (user == null)
            {
                var userName = context.User.Claims.FirstOrDefault(n => n.Type == "name").Value;
                user = new User { Name = userName, Email = userEmail };
                var id = userRepository.Create(user);
                user.Id = id;
            }

            currentUser.Id = user.Id;
            currentUser.Name = user.Name;
            currentUser.Email = user.Email;

            await _next.Invoke(context);
        }
    }
}
