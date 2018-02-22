using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Reverse_And_Exclude
{
    public class Startup
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int divider = int.Parse(Console.ReadLine());

            numbers.Reverse();
            numbers = Filter(numbers, n => n % divider != 0);

            Console.WriteLine(string.Join(" ",numbers));
        }
        public static List<int> Filter(IEnumerable<int> numbers, Func<int,bool> Filter)
        {
            List<int> result = new List<int>();

            foreach (var num in numbers)
            {
                if (Filter(num))
                {
                    result.Add(num);
                }
            }
            return result;
        }
    }
}
