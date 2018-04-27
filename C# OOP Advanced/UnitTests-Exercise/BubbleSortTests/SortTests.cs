using BubleSort;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BubbleSortTests
{
    [TestFixture]
    public class SortTests
    {
        [TestCase(new int[] { 10,1,9,2,8,3,7,4,6,5})]

        public void ShouldReturnSortedCollection(int [] args)
        {
            Bubble<int> numbers = new Bubble<int>(args);

            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            numbers.Sort();

            Assert.That(numbers, Is.EquivalentTo(expected));
        }
    }
}
