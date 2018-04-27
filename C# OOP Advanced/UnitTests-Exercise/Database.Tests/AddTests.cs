using DataBase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Tests
{
    [TestFixture]
    public class AddTests
    {
        private Person p1;
        private Person p2;
        private Database<Person> SUT;

        [SetUp]
        public void Initialize()
        {
            this.p1 = new Person("Pesho", 12345);
            this.p2 = new Person("Pesho", 54321);
            this.SUT = new Database<Person>();
        }

        [Test]
        public void ShouldThrowException_IfUsernameExists()
        {
            this.SUT.Add(p1);

            Assert.Throws<InvalidOperationException>(() => this.SUT.Add(p2), "Added person with same username!");
        }

        [Test]
        public void ShouldThrowException_IfIdExists()
        {
            this.SUT.Add(p1);

            Assert.Throws<InvalidOperationException>(() => this.SUT.Add(p2), "Added person with same Id!");
        }
    }
}
