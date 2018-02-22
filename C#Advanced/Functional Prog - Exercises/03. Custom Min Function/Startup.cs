using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Custom_Min_Function
{
    public class Startup
    {
        public static void Main()
        {
            List<double> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            Func<List<double>, double> Min = GetMin;

            double minNum = Min(numbers);

            Console.WriteLine(minNum);
        }

        public static double GetMin(List<double> numbers)
        {
            double min = double.MaxValue;

            foreach (var num in numbers)
            {
                if (num < min)
                {
                    min = num;
                }
            }

            return min;
        }
    }
}
