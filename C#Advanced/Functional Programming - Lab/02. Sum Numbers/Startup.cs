using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sum_Numbers
{
    public class Startup
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine($"{numbers.Count}");
            Console.WriteLine($"{numbers.Sum()}");
        }
    }
}
