using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Reverse_Numbers
{
    public class RevNumbers
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }
                , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> nums = new Stack<int>(numbers);
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
