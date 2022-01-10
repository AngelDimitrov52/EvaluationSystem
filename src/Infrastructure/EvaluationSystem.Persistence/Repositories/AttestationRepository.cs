using Dapper;
using EvaluationSystem.Application.Models.AttestationModels.Dtos;
using EvaluationSystem.Application.Models.AttestationModels.Interface;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;
using System.Collections.Generic;

namespace EvaluationSystem.Persistence.Repositories
{
    public class AttestationRepository : GenericRepository<Attestation>, IAttestationRepository
    {
        public AttestationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public List<AttestationFromDbDto> GetAllAttestations()
        {
            string query = @"SELECT att.Id ,f.[Name] AS FormName, att.CreateDate,u.[Name] AS UserName,up.[Name] AS ParticipantName, up.[Email] AS ParticipantEmail, ap.[Status]
                             FROM Attestation AS att
                             RIGHT JOIN [User] AS u ON u.Id = att.IdUserToEval
                             RIGHT JOIN AttestationForm AS f ON f.Id = att.IdAttestationForm
                             RIGHT JOIN  AttestationParticipant ap ON ap.IdAttestation = att.Id
                             LEFT JOIN  [User] up ON up.Id = ap.IdUserParticipant";
            var result = Connection.Query<AttestationFromDbDto>(query, null, Transaction);
            return (List<AttestationFromDbDto>)result;
        }
        public void AddParticipantToAttestation(int attestationId, int participantId, string position, int attestationFormId)
        {
            var status = "Open";
            string query = "INSERT INTO [AttestationParticipant] (IdAttestation , IdUserParticipant , [Status],Position, AttestationFormId) VALUES(@IdAttestation, @IdUserParticipant, @Status,@Position,@AttestationFormId);";
            Connection.Execute(query, new { IdAttestation = attestationId, IdUserParticipant = participantId, Status = status, Position = position, AttestationFormId = attestationFormId }, Transaction);
        }
        public void DeleteAttestationFromAttestationParticipant(int attestationId)
        {
            string query = "DELETE FROM AttestationParticipant WHERE IdAttestation= @IdAttestation;";
            Connection.Execute(query, new { IdAttestation = attestationId }, Transaction);
        }
    }
}
