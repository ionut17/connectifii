using System;
using Core;
using FluentAssertions;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class RepositoryTester
    {
        private AbstractRepository<Student> repository;
        private Student student;

        [TestInitialize]
        public void SetUp()
        {
            student = new Student("007", "John", "McDonalds", new Group("D3", 2), DateTime.Now);
        }

        [TestMethod]
        public void When_RepositoryIsInstantiated_Then_ContextShoulNotBeNull()
        {
            AbstractRepository<Student> repository = CreateSut();
            repository.Context.Should().NotBeNull();
        }

        [TestMethod]
        public void When_CreateIsCalled_Then_CreatedEntityShouldExistInBD()
        {
            AbstractRepository<Student> repository = CreateSut();

            repository.Create(student);

            var exists = repository.GetById(student.Id);

            exists.Should().NotBeNull();
        }

        [TestMethod]
        public void When_GetAllIsCalled_Then_ShoulReturnNotEmpty()
        {
            AbstractRepository<Student> repository = CreateSut();

            var result = repository.GetAll();

            result.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void When_GetByIdIsCalled_Then_ShouldReturnNotNull()
        {
            AbstractRepository<Student> repository = CreateSut();

            repository.Create(student);
            var exists = repository.GetById(student.Id);

            exists.Should().NotBeNull();
        }

        /* 
          [TestMethod]
          public void When_DeleteAllIsCalled_Then_ShoulLeaveDatabaseEmpty()
          {
              AbstractRepository<Student> repository = CreateSut();

              repository.DeleteAll();

              var allEntities = repository.GetAll();

              allEntities.Should().BeNullOrEmpty();
          }
          */

        private static StudentRepository CreateSut()
        {
            return new StudentRepository();
        }
    }
}