using AutoMapper;
using EvaluationSystem.Application.Models.Dtos;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Services
{
   public class QuestionService : IQuestionService
    {
        private IMapper _mapper;
        private IQuestionRepository _repository;
        public QuestionService(IMapper mapper, IQuestionRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public QuestionDto GetById(int id)
        {
            Question аnswer = _repository.GetAnswerById(id);

            QuestionDto answerDto = _mapper.Map<QuestionDto>(аnswer);

            return answerDto;
        }
    }
}
