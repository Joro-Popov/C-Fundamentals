using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Squares
{
    public static void Main(string[] args)
    {
        List<int> matrixDimensions = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        int rows = matrixDimensions[0];
        int cols = matrixDimensions[1];

        char[][] matrix = new char[rows][];

        int matricesCount = 0;

        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            matrix[rowIndex] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
            
        }

        for (int rowIndex = 0; rowIndex < matrix.Length - 1; rowIndex++)
        {
            for (int colIndex = 0; colIndex < matrix[rowIndex].Length - 1; colIndex++)
            {
                char currentChar = matrix[rowIndex][colIndex];

                if (matrix[rowIndex][colIndex + 1] == currentChar && 
                    matrix[rowIndex + 1][colIndex] == currentChar && 
                    matrix[rowIndex + 1][colIndex + 1] == currentChar)
                {
                    matricesCount++;
                }
            }
        }

        Console.WriteLine(matricesCount);
    }
}
