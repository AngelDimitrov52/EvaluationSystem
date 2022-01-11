using EvaluationSystem.Application.Models.UserModels.Interface;
using EvaluationSystem.Domain.Entities;
using EvaluationSystem.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class UserServiceTest
    {
        //private IUserService _userService;
        //private ICurrentUser _curentUser;
        private IUserRepository _userRepository;

        [SetUp]
        public void SetUp()
        {
            // _userService = new UserService(_userRepository, _curentUser, new MapperConfiguration((mc) =>
            //{
            //    mc.AddMaps(typeof(AnswerProfile).Assembly);
            //}).CreateMapper());

            var config = new ConfigurationBuilder()
                   .SetBasePath(Environment.CurrentDirectory)
                  .AddJsonFile("appsettings.json")
                  .Build();

            _userRepository = new UserRepository(new UnitOfWork(config));
        }
        [Test]
        public void Verify_UserGetAll_ReturnAllUsers()
        {
            var count = 69;
            var users = _userRepository.GetAll();
            Assert.That(count == users.Count);
        }

        [Test]
        public void Verify_UserGetAll_ReturnCurrentUsers()
        {
            var user = new User { Id = 1, Name = "Angel Dimitrov", Email = "ADimitrov@vsgbg.com" };
            var result = _userRepository.GetAll();

            Assert.That(result[0].Id == user.Id);
            Assert.That(result[0].Name == user.Name);
            Assert.That(result[0].Email == user.Email);
        }
    }
}