using NUnit.Framework;
using System;
using Database;
using DataBase;
using System.Reflection;
using System.Linq;

namespace Database.Tests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Should_InitializeDataCorrectly()
        {
            var persons = new Person[] { new Person("Gosho", 12345), new Person("Pesho", 54321), new Person("Ivan",4444) };

            var sut = new Database<Person>(persons);

            var field = typeof(Database<Person>)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.FieldType == typeof(Person[]));

            var actual = (Person[])field.GetValue(sut);

            Assert.That(actual, Is.EquivalentTo(persons));
        }

        [Test]
        public void Should_ThrowException_IfInvalidArrayLength()
        {

        }
    }
}
