using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataBase;

namespace Database.Tests
{
    [TestFixture]
    public class RemoveTests
    {
        [Test]
        public void ShouldRemoveLastElement()
        {
            Person p1 = new Person("Pesho", 12345);
            Person p2 = new Person("Gosho", 123456);
            var SUT = new Database<Person>(p1, p2);
            var expected = SUT[0].Username;

            SUT.Remove();

            Assert.That(SUT[0].Username, Is.EqualTo(expected), "Last element was not removed!");
        }

        [Test]
        public void ShouldNotRemoveIfCollectionIsEmpty()
        {
            var SUT = new Database<Person>();

            Assert.Throws<InvalidOperationException>(() => SUT.Remove());
        }
    }
}
