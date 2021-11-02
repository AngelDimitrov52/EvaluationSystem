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
        public List<QuestionDto> GetAll()
        {
            List<Question> questions = _repository.GetAll();
            List<QuestionDto> result = _mapper.Map<List<QuestionDto>>(questions);
            return result;
        }
        public QuestionDto GetById(int id)
        {
            Question question = _repository.GetById(id);
            QuestionDto questionDto = _mapper.Map<QuestionDto>(question);
            return questionDto;
        }

        public QuestionDto Update(QuestionDto model)
        {
            Question question = _mapper.Map<Question>(model);
            var result = _repository.Update(question);
            QuestionDto questionDto = _mapper.Map<QuestionDto>(result);
            return questionDto;
        }

        public QuestionDto Create(QuestionDto model)
        {
            Question question = _mapper.Map<Question>(model);
            var result = _repository.AddNew(question);
            QuestionDto questionDto = _mapper.Map<QuestionDto>(result);
            return questionDto;
        }

        public QuestionDto Delete(int id)
        {
            Question question = _repository.Delete(id);
            QuestionDto questionDto = _mapper.Map<QuestionDto>(question);
            return questionDto;
        }
    }
}
