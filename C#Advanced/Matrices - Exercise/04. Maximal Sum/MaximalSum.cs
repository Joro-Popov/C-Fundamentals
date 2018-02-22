using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MaximalSum
{
    public static void Main()
    {
        List<int> matrixDimensions = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        int rows = matrixDimensions[0];
        int cols = matrixDimensions[1];

        int[][] matrix = new int[rows][];

        int maxSum = int.MinValue;
        int bestRow = 0;
        int bestCol = 0;

        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            matrix[rowIndex] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        for (int rowIndex = 0; rowIndex < matrix.Length - 2; rowIndex++)
        {
            for (int colIndex = 0; colIndex < matrix[rowIndex].Length - 2; colIndex++)
            {
                int currentSum = matrix[rowIndex][colIndex] + matrix[rowIndex][colIndex + 1] + matrix[rowIndex][colIndex + 2] +
                                 matrix[rowIndex + 1][colIndex] + matrix[rowIndex + 1][colIndex + 1] + matrix[rowIndex + 1][colIndex + 2] +
                                 matrix[rowIndex + 2][colIndex] + matrix[rowIndex + 2][colIndex + 1] + matrix[rowIndex + 2][colIndex + 2];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    bestRow = rowIndex;
                    bestCol = colIndex;
                }
                                 
            }
        }

        Console.WriteLine($"Sum = {maxSum}");
        Console.WriteLine($"{matrix[bestRow][bestCol]} {matrix[bestRow][bestCol + 1]} {matrix[bestRow][bestCol + 2]}");
        Console.WriteLine($"{matrix[bestRow + 1][bestCol]} {matrix[bestRow + 1][bestCol + 1]} {matrix[bestRow + 1][bestCol + 2]}");
        Console.WriteLine($"{matrix[bestRow + 2][bestCol]} {matrix[bestRow + 2][bestCol + 1]} {matrix[bestRow + 2][bestCol + 2]}");
    }
}
