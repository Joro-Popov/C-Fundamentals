using IteratorTest;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace IteratorTests
{
    [TestFixture]
    public class MoveTests
    {
        private ListIterator collection;
        private string[] args;

        [SetUp]
        public void Initialize()
        {
            args = new string[] { "Pesho", "Gosho", "Stamat", "Ivan" };

            collection = new ListIterator(args);
        }

        [Test]
        public void ShouldMoveIndexToNextPossition()
        {
            int expected = 1;

            collection.Move();

            int currentIndex = (int)this.collection.GetType()
                .GetField("index",BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(this.collection);

            Assert.AreEqual(expected, currentIndex);
        }

        [Test]
        public void ShouldNotMoveIfNoNextElement()
        {
            int expected = this.collection.Count - 1;

            this.collection.GetType()
            .GetField("index", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(this.collection, this.collection.Count - 1);

            int actual = (int)this.collection.GetType()
                .GetField("index", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(this.collection);

            Assert.IsFalse(this.collection.Move());
        }
    }
}
