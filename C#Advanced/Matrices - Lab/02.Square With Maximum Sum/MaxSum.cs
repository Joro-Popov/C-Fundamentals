using System;
using System.Linq;

namespace _02.Square_With_Maximum_Sum
{
    public class MaxSum
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            int bestRow = 0;
            int bestCol = 0;
            int bestSum = 0;

            int[][] matrix = new int[rows][];

            matrix = matrix
                .Select(r => r = new int[cols])
                .Select(r => r = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray())
                .ToArray();

            for (int rowIndex = 0; rowIndex < rows - 1; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols - 1; colIndex++)
                {
                    int tempSum = matrix[rowIndex][colIndex] +
                                  matrix[rowIndex][colIndex + 1] +
                                  matrix[rowIndex + 1][colIndex] +
                                  matrix[rowIndex + 1][colIndex + 1];

                    if (tempSum > bestSum)
                    {
                        bestSum = tempSum;
                        bestRow = rowIndex;
                        bestCol = colIndex;
                    }
                }
            }

            Console.WriteLine
                ($"{matrix[bestRow][bestCol]} {matrix[bestRow][bestCol + 1]}\r\n" +
                 $"{matrix[bestRow + 1][bestCol]} {matrix[bestRow + 1][bestCol + 1]}\r\n" +
                 $"{bestSum}");
        }
    }
}
