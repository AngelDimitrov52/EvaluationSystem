using AutoMapper;
using EvaluationSystem.Application.Helpers.Profiles;
using EvaluationSystem.Application.Models.AnswerModels;
using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using EvaluationSystem.Application.Models.ModuleModels.Interface;
using EvaluationSystem.Application.Models.QuestionModels;
using EvaluationSystem.Application.Models.QuestionModels.Intefaces;
using EvaluationSystem.Application.Services;
using EvaluationSystem.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    class ModuleServiceTests
    {
        private IModuleService _moduleService;
        private IQuestionTemplateService _questionService;
        private IModuleRepository _moduleRepository;
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

            _moduleRepository = new ModuleRepository(new UnitOfWork(config));

            //_questionService = new QuestionTemplateService(new AnswerRepository(new UnitOfWork(config)), new MapperConfiguration((mc) =>
            //{
            //    mc.AddMaps(typeof(AnswerProfile).Assembly);
            //}).CreateMapper(), new QuestionTemplateRepository(new UnitOfWork(config)));

            //_moduleService = new ModuleService(new MapperConfiguration((mc) =>
            //{
            //    mc.AddMaps(typeof(AnswerProfile).Assembly);
            //}).CreateMapper(), _moduleRepository, _questionService, new QuestionTemplateRepository(new UnitOfWork(config)));
        }

        [Test]
        public void Verify_ModuleServiceCreate_CreatesModule()
        {
            var model = new ModuleCreateDto { Name = "Test module!" };

           // var insert = _moduleService.Create(model);

            //var result = _moduleService.GetById(insert.Id);
            //Assert.That(model.Name == result.Name);
        }

        [Test]
        public void Verify_ModuleServiceGetById_ReturnsSameIdDTO()
        {
            //id = 1;
            //var result = _moduleService.GetById(id);
            //Assert.That(result.Id == id);
        }

        [Test]
        public void Verify_ModuleServiceGetAll_ReturnsSameIdDTO()
        {
            //string name = "Test module!";
            //var modules = _moduleService.GetAll();
            //Assert.That(modules[1].Name == name);
        }

        [Test]
        public void Verify_ModuleServiceUpdate_UpdateModule()
        {
            var model = new ModuleCreateDto { Name = "Update!" };
            var updateModule = _moduleService.Update(1, model);
            Assert.That(updateModule.Name == model.Name);
        }
    }
}
