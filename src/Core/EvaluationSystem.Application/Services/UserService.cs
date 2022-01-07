using AutoMapper;
using Azure.Identity;
using EvaluationSystem.Application.Models.UserModels.Dtos;
using EvaluationSystem.Application.Models.UserModels.Interface;
using Microsoft.Graph;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUser _currentUser;

        public UserService(IUserRepository userRepository, ICurrentUser currentUser, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<List<UserGetDto>> GetAll()
        {
            var scopes = new[] { "https://graph.microsoft.com/.default" };
            var tenantId = "50ae1bf7-d359-4aff-91ac-b084dc52111e";
            var clientId = "dc32305c-c493-44e0-9654-0de398e76d50";
            var clientSecret = "1m57Q~ClngoPOBs-AQzcLuRnrQIXYyoX5-yLQ";
            var clientSecretCredential = new ClientSecretCredential(
                tenantId, clientId, clientSecret);
            var graphClient = new GraphServiceClient(clientSecretCredential, scopes);
            var allUsersFormAzure = await GetAllUsersFromAzure(graphClient);


            var users = _userRepository.GetAll();
            return _mapper.Map<List<UserGetDto>>(users);
        }
        public List<UserToEvaluationDto> GetAllUsersToEvaluation()
        {
            int id = _currentUser.Id;
            return _userRepository.GetAllAttestationWithUsersToEvaluation(id);
        }

        private async Task<List<UsersFromAzure>> GetAllUsersFromAzure(GraphServiceClient graphClient)
        {

            var users = await graphClient.Users
                     .Request()
                     .Filter("(accountEnabled eq true)")
                     .GetAsync();

            var allUsers = new List<User>();
            while (true)
            {
                foreach (var user in users.CurrentPage)
                {
                    if (user.UserPrincipalName.EndsWith("@vsgbg.com") && !user.UserPrincipalName.EndsWith("#EXT#@vsgbg.com"))
                    {
                        allUsers.Add(user);
                    }
                }
                if (users.NextPageRequest == null)
                {
                    break;
                }
                users = await users.NextPageRequest.GetAsync();
            }

            var allUsersFormAzure = _mapper.Map<List<UsersFromAzure>>(allUsers);
            foreach (var userFromAzure in allUsersFormAzure)
            {

                var user = _userRepository.GetUserByEmail(userFromAzure.Email);
                if (user == null)
                {
                    var userName = userFromAzure.Name;
                    user = new Domain.Entities.User { Name = userName, Email = userFromAzure.Email };
                    _userRepository.Create(user);
                }
            }
            return allUsersFormAzure;
        }
    }
}
