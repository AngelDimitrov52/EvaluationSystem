using AutoMapper;
using Azure.Identity;
using EvaluationSystem.Application.Models.AttestationModels.Interface;
using EvaluationSystem.Application.Models.AttestationParicipantModels.Interface;
using EvaluationSystem.Application.Models.Exceptions;
using EvaluationSystem.Application.Models.UserModels.Dtos;
using EvaluationSystem.Application.Models.UserModels.Interface;
using Microsoft.Graph;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly string[] scopes = new[] { "https://graph.microsoft.com/.default" };
        private const string tenantId = "50ae1bf7-d359-4aff-91ac-b084dc52111e";
        private const string clientId = "dc32305c-c493-44e0-9654-0de398e76d50";
        private const string clientSecret = "1m57Q~ClngoPOBs-AQzcLuRnrQIXYyoX5-yLQ";

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAttestationParticipantRepository _attestationParticipantRepository;
        private readonly IAttestationService _attestationService;
        private readonly ICurrentUser _currentUser;

        public UserService(IUserRepository userRepository,
                           ICurrentUser currentUser,
                           IMapper mapper,
                           IAttestationParticipantRepository attestationParticipantRepository,
                           IAttestationService attestationService)
        {
            _userRepository = userRepository;
            _attestationService = attestationService;
            _mapper = mapper;
            _currentUser = currentUser;
            _attestationParticipantRepository = attestationParticipantRepository;
        }

        public async Task<List<UserGetDto>> GetAll()
        {
            var clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            var graphClient = new GraphServiceClient(clientSecretCredential, scopes);
            var allUsersFormAzure = await UpdatingUserInDB(graphClient);

            var users = _userRepository.GetAll().OrderBy(x => x.Email).ToList();
            return _mapper.Map<List<UserGetDto>>(users);
        }
        public List<UserToEvaluationDto> GetAllUsersToEvaluation()
        {
            int id = _currentUser.Id;
            return _userRepository.GetAllAttestationWithUsersToEvaluation(id);
        }

        private async Task<List<UsersFromAzure>> UpdatingUserInDB(GraphServiceClient graphClient)
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
            if (allUsersFormAzure.Count == 0)
            {
                throw new HttpException("Something wrong with users from Graph Microsoft!", HttpStatusCode.BadRequest);
            }
            var usersFromDB = _userRepository.GetAll();

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

            foreach (var userFromDb in usersFromDB)
            {
                bool isExists = false;
                foreach (var userFromAzure in allUsersFormAzure)
                {
                    if (userFromDb.Email == userFromAzure.Email)
                    {
                        isExists = true;
                        break;
                    }
                }
                if (isExists == false)
                {
                    var allParicipatUsers = _attestationParticipantRepository.GetAllParticipantWithUserId(userFromDb.Id);
                    foreach (var user in allParicipatUsers)
                    {
                        _attestationService.Delete(user.IdAttestation);
                    }
                    _userRepository.DeleteByEmail(userFromDb.Email);
                }
            }

            return allUsersFormAzure;
        }
    }
}
