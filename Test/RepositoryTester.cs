using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class RepositoryTester
    {
        private ICollection<Student> entries;
        private AbstractRepository<Student> repository;

        [TestInitialize]
        public void SetUp()
        {
            repository = new StudentRepository();
            entries = new Collection<Student>();
        }
    }
}