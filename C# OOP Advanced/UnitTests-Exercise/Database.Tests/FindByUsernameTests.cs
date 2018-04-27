using DataBase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Tests
{
    [TestFixture]
    public class FindByUsernameTests
    {
        private Database<Person> dataBase;
        private string username;

        [SetUp]
        public void Initialize()
        {
            this.dataBase = new Database<Person>()
            {
                new Person("Pesho",12345),
                new Person("Gosho", 33333),
                new Person("Stamat", 44444)
            };
        }

        [Test]
        public void ShouldFindByUsername()
        {
            this.username = "Pesho";

            Assert.That(dataBase.FindByUsername(username).Username, Is.EqualTo(username));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ShouldThrowIfUsernameIfNullOrEmpty(string name)
        {
            this.username = name;

            Assert.Throws<InvalidOperationException>(() => dataBase.FindByUsername(username), "Username was null or empty!");
        }

        [Test]
        public void ShouldThrowIfNoUsernameExistsWithCurrentName()
        {
            this.username = "Ivan";

            Assert.Throws<InvalidOperationException>(() => dataBase.FindByUsername(username));
        }

        [Test]
        public void ShouldReturnCorrectObject()
        {
            this.username = "Gosho";

            var person = this.dataBase.FindByUsername(username);

            Assert.That(person.Username, Is.EqualTo(username));
        }
    }
}
