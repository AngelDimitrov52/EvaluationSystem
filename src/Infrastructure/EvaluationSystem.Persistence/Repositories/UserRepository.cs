using Dapper;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Application.Models.UserModels.Dtos;
using EvaluationSystem.Application.Models.UserModels.Interface;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public List<UserToEvaluationDto> GetAllAttestationWithUsersToEvaluation(int participantId)
        {
            string query = @"SELECT att.Id AS AttestationId, f.Id FormId ,u.Email
                             FROM Attestation AS att
                             RIGHT JOIN [User] AS u ON u.Id = att.IdUserToEval
                             RIGHT JOIN FormTemplate AS f ON f.Id = att.IdFormTemplate
                             RIGHT JOIN  AttestationParticipant ap ON ap.IdAttestation = att.Id
							 WHERE ap.IdUserParticipant = @IdUserParticipant AND ap.[Status] = 'Open';";
            var result = Connection.Query<UserToEvaluationDto>(query, new { IdUserParticipant = participantId }, Transaction);
            return (List<UserToEvaluationDto>)result;
        }
        public User GetUserByEmail(string email)
        {
            string query = @"SELECT * FROM [User] WHERE Email = @Email";
            var result = Connection.QueryFirstOrDefault<User>(query, new { Email = email }, Transaction);
            return result;
        }
    }
}
