using System;
using System.Linq;

namespace _03.Group_Numbers
{
    public class GroupNumbers
    {
        public static void Main()
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] zero = inputNumbers.Where(n => Math.Abs(n) % 3 == 0).ToArray();
            int[] one = inputNumbers.Where(n => Math.Abs(n) % 3 == 1).ToArray();
            int[] two = inputNumbers.Where(n => Math.Abs(n) % 3 == 2).ToArray();

            Console.WriteLine($"{string.Join(" ", zero)}\r\n" +
                              $"{string.Join(" ",one)}\r\n" +
                              $"{string.Join(" ",two)}");
        }
    }
}
