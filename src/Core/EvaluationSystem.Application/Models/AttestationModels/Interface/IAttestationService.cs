using EvaluationSystem.Application.Models.AttestationModels.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.AttestationModels.Interface
{
    public interface IAttestationService
    {
        List<AttestationGetDto> GetAll();
        AttestationGetDto Create(AttestationCreateDto model);
        void Delete(int attestationId);
    }
}
