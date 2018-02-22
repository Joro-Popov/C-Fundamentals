using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Add_VAT
{
    public class Startup
    {
        public static void Main()
        {
            List<double> numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(w => w *= 1.2)
                .ToList();

            foreach (var num in numbers)
            {
                Console.WriteLine($"{num:f2}");
            }
        }
    }
}
