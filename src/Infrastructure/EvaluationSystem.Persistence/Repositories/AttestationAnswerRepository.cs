using Dapper;
using EvaluationSystem.Application.Models.AttestationAnswerModel.Interface;
using EvaluationSystem.Application.Models.GenericRepository;
using EvaluationSystem.Domain.Entities;

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
    }
}
