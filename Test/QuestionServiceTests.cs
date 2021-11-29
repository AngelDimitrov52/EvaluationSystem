using System;
using System.Collections.Generic;
using System.Net;
using AutoMapper;
using EvaluationSystem.Application.Helpers.Profiles;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using EvaluationSystem.Application.Models.Exceptions;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using EvaluationSystem.Application.Models.QuestionModels.Intefaces;
using EvaluationSystem.Application.Services;
using EvaluationSystem.Application.Services.HelpServices;
using EvaluationSystem.Domain.Entities;
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

        private IQuestionTemplateService _questionService;
        private IQuestionRepository _questionRepository;
        private string name;
        private int id;

        [SetUp]
        public void SetUp()
        {
            var answerRepoMock = new Mock<IAnswerRepository>();
            var questionRepoMock = new Mock<IQuestionRepository>();

            var config = new ConfigurationBuilder()
                   .SetBasePath(Environment.CurrentDirectory)
                  .AddJsonFile("appsettings.json")
                  .Build();

            //_questionRepository = new QuestionRepository(new UnitOfWork(config));

            //_questionService = new QuestionTemplateService(new AnswerRepository(new UnitOfWork(config)), new MapperConfiguration((mc) =>
            // {
            //     mc.AddMaps(typeof(AnswerProfile).Assembly);
            // }).CreateMapper(), new QuestionTemplateRepository(new UnitOfWork(config)));
        }

        [Test]
        public void Verify_QuestionServiceGetById_ReturnsSameIdDTO()
        {
            id = 1;
            var result = _questionService.GetById(id);
            Assert.That(result.Id == id);
        }

        [Test]
        public void Verify_QuestionServiceCreate_CreatesQuestion()
        {
            //var insertable = new QuestionCreateDto()
            //{
            //    Name = "asd",
            //    IsReusable = true,
            //    Type = AnswersTypes.RadioButtons,
            //    Answers = new List<AnswerCreateDto>()
            //    {
            //        new() { AnswerText = "Test" }
            //    }
            //};

            //var insert = _questionService.Create(new QuestionCreateDto()
            //{
            //    //Name = "asd",
            //    //IsReusable = true,
            //    //Type = AnswersTypes.RadioButtons,
            //    //Answers = new List<AnswerCreateDto>()
            //    //{
            //    //    new() { AnswerText = "Test" }
            //    //}
            //});

            //var result = _questionService.GetById(insert.Id);
            //Assert.That(insertable.Name == result.Name);
        }
        [Test]
        public void Verify_QuestionServiceUpdate_UpdateQuestion()
        {
            //id = 1;
            //string name = "What's your name?";
            //QuestionUpdateDto dto = new QuestionUpdateDto { IsReusable = true, Name = name, Type = AnswersTypes.CheckBoxes };
            //var Update = _questionService.Update(id, dto);
            //var result = _questionService.GetById(id);
            //Assert.That(Update.Name == result.Name);
        }
        [Test]
        public void Verify_QuestionServiceGetById_ThrowWhenIdIsInvalid()
        {
            id = 2332;
            Assert.Throws<HttpException>(() => _questionService.GetById(id));
        }
        [Test]
        public void Verify_QuestionServiceIsQuestionExist_ThrowWhenIdIsInvalid()
        {
            id = 2332;
            Assert.Throws<HttpException>(() => ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(id, _questionRepository)); 
        }
        [Test]
        public void Verify_QuestionServiceGetAll_ReturnCurrentResult()
        {
            name = "What's your name?";
            id = 1;

            var result = _questionService.GetAll();
            Assert.That(result[0].Id == id);
            Assert.That(result[0].Name == name);
        }

        [Test]
        public void Verify_QuestionServiceDelete_DeleteEntity()
        {
            id = 5;
            _questionService.Delete(id);

            Assert.Throws<HttpException>(() => ThrowExceptionHeplService.ThrowExceptionWhenEntityDoNotExist<QuestionTemplate>(id, _questionRepository));
        }
    }
}