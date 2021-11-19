using System;
using System.Collections.Generic;
using AutoMapper;
using EvaluationSystem.Application.Helpers.Profiles;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Application.Services;
using EvaluationSystem.Domain.Enums;
using EvaluationSystem.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class QuestionServiceTests
    {
        private const int QuestionId = 1;
        
        private IQuestionService _questionService;

        private QuestionRepositoryDto _questionRepositoryDto;
        
        [SetUp]
        public void SetUp()
        {
            _questionRepositoryDto = new QuestionRepositoryDto()
            {
                QuestionId = QuestionId,
                AnswerId = 12
            };
            
            var answerRepoMock = new Mock<IAnswerRepository>();
            var questionRepoMock = new Mock<IQuestionRepository>();

            // questionRepoMock.Setup(m => m.GetQuestionById(It.IsAny<int>()))
            //     .Returns(new List<QuestionRepositoryDto> { _questionRepositoryDto });

            var config = new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

            _questionService = new QuestionService(new AnswerDB(config), new MapperConfiguration((mc) =>
            {
                mc.AddMaps(typeof(AnswerProfile).Assembly);
            }).CreateMapper(), new QuestionDB(config));
        }

        [Test]
        public void Verify_QuestionServiceGetById_ReturnsSameIdDTO()
        {
            var result = _questionService.GetById(QuestionId);
            
            Assert.That(result.Id == QuestionId);
            Assert.That(result.Answers[0].Id == 1);
        }

        [Test]
        public void Verify_QuestionServiceCreate_CreatesQuestion()
        {
            var insertable = new QuestionCreateDto()
            {
                Name = "asd",
                IsReusable = true,
                Type = AnswersTypes.RadioButtons,
                Answers = new List<AnswerCreateDto>()
                {
                    new() { AnswerText = "Test" }
                }
            };
            
            var insert = _questionService.Create(new QuestionCreateDto()
            {
                Name = "asd",
                IsReusable = true,
                Type = AnswersTypes.RadioButtons,
                Answers = new List<AnswerCreateDto>()
                {
                    new() { AnswerText = "Test" }
                }
            });

            var result = _questionService.GetById(insert.Id);
            
            Assert.That(insertable.Name == result.Name);
        }
    }
}