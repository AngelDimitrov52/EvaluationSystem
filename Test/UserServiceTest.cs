﻿using AutoMapper;
using EvaluationSystem.Application.Helpers.Profiles;
using EvaluationSystem.Application.Models.UserModels.Dtos;
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

        [SetUp]
        public void SetUp()
        {
            var config = new ConfigurationBuilder()
                   .SetBasePath(Environment.CurrentDirectory)
                  .AddJsonFile("appsettings.json")
                  .Build();

            _userRepository = new UserRepository(new UnitOfWork(config));
            _userService = new UserService(_userRepository, new MapperConfiguration((mc) =>
            {
                mc.AddMaps(typeof(AnswerProfile).Assembly);
            }).CreateMapper());
        }
        [Test]
        public void Verify_UserGetAll_ReturnAllUsers()
        {
            var count = 3;
            var users = _userService.GetAll();
            Assert.That(count == users.Count);
        }

        [Test]
        public void Verify_UserGetAll_ReturnCurrentUsers()
        {
            var user = new User { Id = 1, Name = "Angel", Email = "angel@gmail.com" };
            var result = _userService.GetAll().FirstOrDefault();

            Assert.That(result.Id == user.Id); ;
            Assert.That(result.Name == user.Name);
            Assert.That(result.Email == user.Email);
        }
        [Test]
        public void Verify_UserGetAllUsersToEvaluation_ReturnCurrentUsers()
        {
            var participantId = 1;

            var user = new UserToEvaluationDto { AttestationId = 9, FormName = "FORM 1", Email = "gosho@gmail.com" };
            var result = _userService.GetAllUsersToEvaluation(participantId).FirstOrDefault();

            Assert.That(result.AttestationId == user.AttestationId); ;
            Assert.That(result.FormName == user.FormName);
            Assert.That(result.Email == user.Email);
        }
        [Test]
        public void Verify_UserGetAllUsersToEvaluation_ReturnCurrentCountOfUsers()
        {
            var participantId = 1;
            var result = _userService.GetAllUsersToEvaluation(participantId);
            var count = 2;

            Assert.That(result.Count == count);
        }
    }
}