using System;
using System.Linq;
using System.Collections.Generic;

namespace _09._List_Of_Predicates
{
    public static class MyExtenssions
    {
        public static List<int> Extract(this List<int>collection, Func<int, bool> checker)
        {
            List<int> result = new List<int>();

            foreach (var num in collection)
            {
                if (checker(num))
                {
                    result.Add(num);
                }
            }
            return result;
        }
    }
    public class Startup
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            List<int> dividors = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            for (int current = 1; current <= count; current++)
            {
                result.Add(current);
            }
            foreach (var div in dividors)
            {
                result = result.Extract(n => n % div == 0);
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
