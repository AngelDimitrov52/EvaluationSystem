using AutoMapper;
using EvaluationSystem.Application.Helpers.Profiles;
using EvaluationSystem.Application.Models.UserModels.Interface;
using EvaluationSystem.Application.Services;
using EvaluationSystem.Domain.Entities;
using EvaluationSystem.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class UserServiceTest
    {   
        private IUserService _userService;
        private IUserRepository _userRepository;
        private ICurrentUser curentUser;

        [SetUp]
        public void SetUp()
        {
            var config = new ConfigurationBuilder()
                   .SetBasePath(Environment.CurrentDirectory)
                  .AddJsonFile("appsettings.json")
                  .Build();

            _userRepository = new UserRepository(new UnitOfWork(config));
            _userService = new UserService(_userRepository, curentUser, new MapperConfiguration((mc) =>
           {
               mc.AddMaps(typeof(AnswerProfile).Assembly);
           }).CreateMapper());
        }
        [Test]
        public void Verify_UserGetAll_ReturnAllUsers()
        {
            var count = 1;
            var users = _userService.GetAll();
            Assert.That(count == users.Count);
        }

        [Test]
        public void Verify_UserGetAll_ReturnCurrentUsers()
        {
            var user = new User { Id = 1, Name = "Angel Dimitrov", Email = "ADimitrov@vsgbg.com" };
            var result = _userService.GetAll().FirstOrDefault();

            Assert.That(result.Id == user.Id);
            Assert.That(result.Name == user.Name);
            Assert.That(result.Email == user.Email);
        }
    }
}