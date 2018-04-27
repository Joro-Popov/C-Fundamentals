using IteratorTest;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace IteratorTests
{
    [TestFixture]
    public class HasNextMEthodTests
    {
        private IListIterator collection;

        [SetUp]
        public void Inizialize()
        {
            collection = new ListIterator(new string[] { "Pesho", "Gosho", "Ivan" });
        }

        [Test]
        public void ShouldReturnTrueIfHasNextElement()
        {
            Assert.IsTrue(this.collection.HasNext());
        }

        [Test]
        public void ShouldReturnFlaseIfHasNoNextElement()
        {
            this.collection.GetType()
                .GetField("index", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(this.collection, this.collection.Count - 1);

            Assert.IsFalse(this.collection.HasNext());
        }
    }
}
