using Dapper;
using EvaluationSystem.Application.Models.AttestationAnswerModel.Interface;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Persistence.Repositories
{
    public class AttestationAnswerRepository : GenericRepository<AttestationAnswer>, IAttestationAnswerRepository
    {
        public AttestationAnswerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public void ChangeUserStatusToDone(int attestationId, int userId)
        {
            var status = "Done";
            string query = "  UPDATE AttestationParticipant SET[Status] = @Status WHERE IdAttestation = @IdAttestation AND IdUserParticipant = @IdUserParticipant; ";
            Connection.Execute(query, new { IdAttestation = attestationId, IdUserParticipant = userId, Status = status }, Transaction);
        }
        public List<AttestationAnswer> GetAllAttestationAnswerByUserAndAttestation(int attestationId, int userId)
        {
            string query = @"SELECT * FROM [AttestationAnswer] WHERE IdAttestation = @IdAttestation AND IdUserParticipant = @IdUserParticipant";
            var result = Connection.Query<AttestationAnswer>(query, new { IdAttestation = attestationId , IdUserParticipant = userId }, Transaction);
            return (List<AttestationAnswer>)result;
        }
    }
}
