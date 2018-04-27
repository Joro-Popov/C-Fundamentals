using IteratorTest;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IteratorTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void ShouldThrowIfNullCollectionIsPassed()
        {
            ListIterator collection = null;

            Assert.Throws<ArgumentNullException>(() => collection = new ListIterator(null), "Passed collection was empty!");
        }

        [Test]
        public void Should_Set_Values_Properly()
        {
            List<string> expected = new List<string>()
            {
                "Pesho","Gosho","Ivan","Stamat"
            };

            var listInterator = new ListIterator(expected);

            var collection = typeof(ListIterator)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.FieldType == typeof(IEnumerable<string>));

            var actual = (IEnumerable<string>)collection.GetValue(listInterator);

            Assert.That(expected, Is.EquivalentTo(actual));
        }
    }
}
