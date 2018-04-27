using DataBase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Tests
{
    [TestFixture]
    public class FindByIdTests
    {
        private Database<Person> dataBase;

        [SetUp]
        public void Initialize()
        {
            this.dataBase = new Database<Person>()
            {
                new Person("Pesho", 12345),
                new Person("Gosho", 123456),
                new Person("Stamat", 54321)
            };
        }

        [TestCase(22)]
        [TestCase(-22)]

        public void ShouldThrowIfNoSuchIdFound(int id)
        {
            Assert.Throws<InvalidOperationException>(() => this.dataBase.FindById(id));
        }

        [Test]
        public void Should_ReturnCorrectObjectById()
        {
            var expected = this.dataBase[0].Id;

            var actual = this.dataBase.FindById(12345).Id;

            Assert.AreEqual(expected, actual);
        }
    }
}
