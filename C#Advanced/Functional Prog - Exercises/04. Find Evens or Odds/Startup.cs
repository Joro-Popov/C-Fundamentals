using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Find_Evens_or_Odds
{
    public class Startup
    {
        public static void Main()
        {
            List<int> arguments = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int start = arguments[0];
            int end = arguments[1];

            string condition = Console.ReadLine();

            var filter = CreateFilter(condition);

            for (int i = start; i <= end; i++)
            {
                if (filter(i))
                {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();
        }
        public static Func<int, bool> CreateFilter(string condition)
        {
            switch (condition)
            {
                case "odd": return n => n % 2 != 0;
                case "even": return n => n % 2 == 0;
                default: return null;
            }
        }
    }
}
