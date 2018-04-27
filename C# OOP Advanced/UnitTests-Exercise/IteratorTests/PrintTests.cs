using IteratorTest;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorTests
{
    [TestFixture]
    public class PrintTests
    {
        [Test]
        public void ShouldThrowIfCollectionIsEmpty()
        {
            var collection = new ListIterator(new List<string>());
            
            Assert.Throws<InvalidOperationException>(() => collection.Print());
        }
    }
}
