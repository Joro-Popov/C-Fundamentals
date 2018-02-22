using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Knights_of_Honor
{
    public class Startup
    {
        public static void Main()
        {
            Action<string> appendPrefix = s => Console.WriteLine($"Sir {s}");

            List<string> names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            names.ForEach(s => appendPrefix(s));
                
        }
    }
}
