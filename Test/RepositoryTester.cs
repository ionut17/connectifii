using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using FluentAssertions;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test
{
    [TestClass]
    public class RepositoryTester
    {
        private Student _student;

        [TestInitialize]
        public void SetUp()
        {
            _student = new Student("801", "John", "McDonalds", new Group("B7", 3), DateTime.Now);
        }

        [TestMethod]
        public void When_RepositoryIsInstantiated_Then_ContextShoulNotBeNull()
        {
            var mockSet = new Mock<DbSet<Student>>();

            var mockContext = new Mock<BaseContext>();
            mockContext.Setup(c => c.Students).Returns(mockSet.Object);

            var repository = new StudentRepository(mockContext.Object);
            repository.Context.Should().NotBeNull();
        }

        [TestMethod]
        public void When_CreateIsCalled_Then_AddAndSaveChangesShouldBeCalled()
        {
            var mockSet = new Mock<DbSet<Student>>();

            var mockContext = new Mock<BaseContext>();
            mockContext.Setup(c => c.Students).Returns(mockSet.Object);

            var repository = new StudentRepository(mockContext.Object);
            repository.Create(_student);

            mockContext.Verify(c => c.Add(It.IsAny<Student>()), Times.Once());
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void When_UpdateIsCalled_Then_UpdateAndSaveChangesShouldBeCalled()
        {
            var mockSet = new Mock<DbSet<Student>>();

            var mockContext = new Mock<BaseContext>();
            mockContext.Setup(c => c.Students).Returns(mockSet.Object);

            var repository = new StudentRepository(mockContext.Object);
            repository.Update(_student);

            mockContext.Verify(c => c.Update(It.IsAny<Student>()), Times.Once());
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void When_GetAllIsCalled_Then_ShoulReturnNotEmpty()
        {
            var data = new List<Student>
            {
                new Student("010", "Ana", "Maria", new Group("A1", 1), DateTime.Now),
                new Student("020", "Alex", "Andrei", new Group("B1", 2), DateTime.Now),
                new Student("030", "Dan", "Miron", new Group("B2", 3), DateTime.Now)
            };
            var queryable = data.AsQueryable();
            var mockSet = new Mock<DbSet<Student>>();

            var mockContext = new Mock<BaseContext>();
            mockContext.Setup(c => c.Students).Returns(mockSet.Object);
            mockSet.As<IQueryable<Student>>().Setup(s => s.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<Student>>().Setup(s => s.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<Student>>().Setup(s => s.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<Student>>().Setup(s => s.GetEnumerator()).Returns(queryable.GetEnumerator());
            mockContext.Setup(c => c.Set<Student>()).Returns(mockSet.Object);

            var repository = new StudentRepository(mockContext.Object);
            var result = repository.GetAll();

            result.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void When_GetByIdIsCalled_Then_ShouldReturnNotNull()
        {
            var mockSet = new Mock<DbSet<Student>>();

            var mockContext = new Mock<BaseContext>();
            mockContext.Setup(c => c.Students).Returns(mockSet.Object);
            mockContext.Setup(c => c.Find<Student>(_student.Id)).Returns(_student);

            var repository = new StudentRepository(mockContext.Object);
            var exists = repository.GetById(_student.Id);

            exists.Should().NotBeNull();
        }


        [TestMethod]
        public void When_DeleteIsCalled_Then_RemoveAndSaveChangesShouldBeCalled()
        {
            var mockSet = new Mock<DbSet<Student>>();

            var mockContext = new Mock<BaseContext>();
            mockContext.Setup(c => c.Students).Returns(mockSet.Object);

            var repository = new StudentRepository(mockContext.Object);
            repository.Delete(_student);

            mockContext.Verify(c => c.Remove(_student), Times.Once);
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }


        private static StudentRepository CreateSut()
        {
            return new StudentRepository(new BaseContext());
        }
    }
}