using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[][] matrix = new int[matrixSize][];

            int primarySum = 0;
            int secondarySum = 0;
            int difference = 0;

            for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                primarySum += matrix[rowIndex][rowIndex];
                secondarySum += matrix[rowIndex][matrix.Length - 1 - rowIndex];
            }

            difference = Math.Abs(primarySum - secondarySum);
            Console.WriteLine(difference);
        }
    }
}
