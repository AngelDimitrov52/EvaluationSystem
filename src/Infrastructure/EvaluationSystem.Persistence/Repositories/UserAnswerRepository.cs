using Dapper;
using EvaluationSystem.Application.Models.AttestationAnswerModel.Interface;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Persistence.Repositories
{
    public class UserAnswerRepository : GenericRepository<UserAnswer>, IUserAnswerRepository
    {
        public UserAnswerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public void ChangeUserStatusToDone(int attestationId, int userId)
        {
            var status = "Done";
            string query = "  UPDATE AttestationParticipant SET[Status] = @Status WHERE IdAttestation = @IdAttestation AND IdUserParticipant = @IdUserParticipant; ";
            Connection.Execute(query, new { IdAttestation = attestationId, IdUserParticipant = userId, Status = status }, Transaction);
        }
        public List<UserAnswer> GetAllAttestationAnswerByUserAndAttestation(int attestationId, int userId)
        {
            string query = @"SELECT * FROM [UserAnswer] WHERE IdAttestation = @IdAttestation AND IdUserParticipant = @IdUserParticipant";
            var result = Connection.Query<UserAnswer>(query, new { IdAttestation = attestationId, IdUserParticipant = userId }, Transaction);
            return (List<UserAnswer>)result;
        }
        public void DeleteWithAttestationId(int atteatationId)
        {
            string query = "Delete from [UserAnswer] where [IdAttestation] = @IdAttestation";
            Connection.Execute(query, new { IdAttestation = atteatationId }, Transaction);
        }
    }
}
