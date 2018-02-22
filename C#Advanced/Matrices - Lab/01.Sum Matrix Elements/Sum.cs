using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Sum_Matrix_Elements
{
    public class Sum
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new string[] { ", "},StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            int sum = 0;

            int[][] matrix = new int[rows][];

            matrix = matrix
                .Select(r => r = new int[cols])
                .Select(r => r = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray())
                .ToArray();

            foreach (var row in matrix)
            {
                sum += row.Sum();
            }

            Console.WriteLine($"{rows}\r\n{cols}\r\n{sum}");
        }
    }
}
