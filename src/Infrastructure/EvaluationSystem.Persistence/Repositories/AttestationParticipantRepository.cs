using Dapper;
using EvaluationSystem.Application.Models.AttestationParicipantModels.Interface;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Persistence.Repositories
{
    public class AttestationParticipantRepository : GenericRepository<AttestationParticipant>, IAttestationParticipantRepository
    {
        public AttestationParticipantRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public List<AttestationParticipant> GetAllUserParticipatnByAttestationId(int attestationId)
        {
            string query = @"SELECT * FROM AttestationParticipant
                              WHERE IdAttestation = @IdAttestation";
            var result = Connection.Query<AttestationParticipant>(query, new { IdAttestation = attestationId }, Transaction);
            return (List<AttestationParticipant>)result;
        }
        public AttestationParticipant GetAllParticipantFormId(int attestationId, int userId)
        {
            string query = @" SELECT * FROM AttestationParticipant
                              WHERE IdAttestation = @IdAttestation AND IdUserParticipant = @IdUserParticipant";
            var result = Connection.QueryFirstOrDefault<AttestationParticipant>(query, new { IdAttestation = attestationId, IdUserParticipant = userId }, Transaction);
            return (AttestationParticipant)result;
        }
    }
}
