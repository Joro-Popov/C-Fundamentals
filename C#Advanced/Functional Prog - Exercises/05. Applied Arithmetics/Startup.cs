using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Applied_Arithmetics
{
    public class Startup
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add": numbers = ApplyCommand(numbers, n => n + 1); break;
                    case "multiply": numbers = ApplyCommand(numbers, n => n * 2); break;
                    case "subtract": numbers = ApplyCommand(numbers, n => n - 1); break;
                    case "print": Console.WriteLine(string.Join(" ",numbers)); break;
                }
                
                command = Console.ReadLine();
            }
        }
        static List<int> ApplyCommand(List<int> numbers,Func<int,int> Operation)
        {
            List<int> result = new List<int>();

            foreach (var num in numbers)
            {
                result.Add(Operation(num));
            }

            return result;
        }
    }
}
