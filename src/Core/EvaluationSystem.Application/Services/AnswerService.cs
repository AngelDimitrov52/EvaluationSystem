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
        public List<AnswerDto> GetAll()
        {
            List<Аnswer> аnswer = _repository.GetAll();
            List<AnswerDto> result = _mapper.Map<List<AnswerDto>>(аnswer);
            return result;
        }
        public AnswerDto GetById(int id)
        {
            Аnswer аnswer = _repository.GetById(id);
            AnswerDto answerDto = _mapper.Map<AnswerDto>(аnswer);
            return answerDto;
        }

        public AnswerDto Delete(int id)
        {
            Аnswer аnswer = _repository.Delete(id);
            AnswerDto answerDto = _mapper.Map<AnswerDto>(аnswer);
            return answerDto;
        }

        public AnswerDto Create(AnswerDto model)
        {
            Аnswer answer = _mapper.Map<Аnswer>(model);
            var result =_repository.AddNew(answer);
            AnswerDto answerDto = _mapper.Map<AnswerDto>(result);
            return answerDto;
        }

        public AnswerDto Update(AnswerDto model)
        {
            Аnswer answer = _mapper.Map<Аnswer>(model);
            var result = _repository.Update(answer);
            AnswerDto answerDto = _mapper.Map<AnswerDto>(result);
            return answerDto;
        }
    }
}
