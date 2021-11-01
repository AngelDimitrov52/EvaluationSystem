using AutoMapper;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Services.AnswerService
{
   public class AnswerService : IAnswerService
    {
        private IMapper _mapper;
        private IAnswerRepository _repository;
        public AnswerService(IMapper mapper, IAnswerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public AnswerDto GetById(int id)
        {
            АnswerEntity аnswer = _repository.GetAnswerById(id);

            AnswerDto answerDto = _mapper.Map<AnswerDto>(аnswer);

            return answerDto;
        }
    }
}
