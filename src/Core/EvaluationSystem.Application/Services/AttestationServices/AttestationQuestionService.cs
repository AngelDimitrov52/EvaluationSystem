using AutoMapper;
using EvaluationSystem.Application.Models.AttestationAnswerModels.Interface;
using EvaluationSystem.Application.Models.AttestationQuestionModels.Dtos;
using EvaluationSystem.Application.Models.AttestationQuestionModels.Interface;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Domain.Entities.AttestationEntities;
using EvaluationSystem.Domain.Enums;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Services.AttestationServices
{
    public class AttestationQuestionService : IAttestationQuestionService
    {
        private readonly IAttestationQuestionRepository _attestationQuestionRepository;
        private readonly IAttestationAnswerRepository _attestationAnswerRepository;
        private readonly IAttestationAnswerService _attestationAnswerService;
        private readonly IMapper _mapper;

        public AttestationQuestionService(IAttestationQuestionRepository attestationQuestionRepository,
                                          IMapper mapper,
                                          IAttestationAnswerService attestationAnswerService,
                                          IAttestationAnswerRepository attestationAnswerRepository)
        {
            _attestationQuestionRepository = attestationQuestionRepository;
            _mapper = mapper;
            _attestationAnswerService = attestationAnswerService;
            _attestationAnswerRepository = attestationAnswerRepository;
        }
        public void Create(int moduleId, QuestionCreateDto model)
        {
            var question = _mapper.Map<AttestationQuestion>(model);
            question.IsReusable = false;
            int questionId = _attestationQuestionRepository.Create(question);

            _attestationQuestionRepository.AddAttestationQuestionToAttestationModule(moduleId, questionId, model.Position);

            foreach (var answer in model.Answers)
            {
                _attestationAnswerService.Create(questionId, answer);
            }
        }
        public List<QuestionGetDto> GetAll(int moduleId)
        {
            var result = new List<QuestionGetDto>();
            var questionsInModule = _attestationQuestionRepository.GetModuleQuestions(moduleId);
            foreach (var questionInModule in questionsInModule)
            {
                var question = _attestationQuestionRepository.GetById(questionInModule.IdQuestion);
                var mapQuestion = _mapper.Map<QuestionGetDto>(question);
                mapQuestion.Answers = _attestationAnswerService.GetAll(mapQuestion.Id);
                mapQuestion.Position = questionInModule.Position;
                result.Add(mapQuestion);
            }
            return result;
        }
        public void Update(AttestationQuestionUpdateDto attestationQuestionUpdateDto)
        {
            var questionFromDB = _attestationQuestionRepository.GetById(attestationQuestionUpdateDto.attestationQuestionId);

            if (questionFromDB.Type == AnswersTypes.TextField)
            {
                questionFromDB.AnswerText = attestationQuestionUpdateDto.AnswerText;
                _attestationQuestionRepository.Update(questionFromDB);
            }
            else
            {
                var answers = _attestationAnswerRepository.GetAllByQuestionId(attestationQuestionUpdateDto.attestationQuestionId);
                foreach (var answer in answers)
                {
                    if (answer.IsDefault == true)
                    {
                        answer.IsDefault = false;
                        _attestationAnswerRepository.Update(answer);
                    }
                }

                foreach (var answerId in attestationQuestionUpdateDto.AnswerIds)
                {
                    var defaultAnswer = _attestationAnswerRepository.GetById(answerId);
                    defaultAnswer.IsDefault = true;
                    _attestationAnswerRepository.Update(defaultAnswer);
                }

            }
        }
        public void Delete(int questionId)
        {
            _attestationQuestionRepository.DeleteQuestionFromModule(questionId);
            _attestationAnswerRepository.DeleteWithQuestionId(questionId);
            _attestationQuestionRepository.Delete(questionId);
        }
    }
}
