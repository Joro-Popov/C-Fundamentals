using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { '(', ')' }
                , StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int rotation = int.Parse(input[1]);
            int maxLength = int.MinValue;

            List<List<char>> matrix = new List<List<char>>();
            matrix = matrix.Select(l => l = new List<char>()).ToList();

            string currentLine = Console.ReadLine();

            FillMatrix(ref maxLength, matrix, ref currentLine);
            RearrangeMatrix(maxLength, matrix);

            int rotationDegrees = rotation % 360;

            PrintResult(maxLength, matrix, rotationDegrees);

        }

        public static void PrintResult(int maxLength, List<List<char>> matrix, int rotationDegrees)
        {
            if (rotationDegrees == 0 || rotationDegrees == 360)
            {
                foreach (var list in matrix)
                {
                    Console.WriteLine(string.Join("", list));
                }
            }
            else if (rotationDegrees == 90)
            {
                for (int colIndex = 0; colIndex < maxLength; colIndex++)
                {
                    for (int rowIndex = matrix.Count - 1; rowIndex >= 0; rowIndex--)
                    {
                        Console.Write(matrix[rowIndex][colIndex]);
                    }
                    Console.WriteLine();
                }
            }
            else if (rotationDegrees == 180)
            {
                for (int rowIndex = matrix.Count - 1; rowIndex >= 0; rowIndex--)
                {
                    for (int colIndex = maxLength - 1; colIndex >= 0; colIndex--)
                    {
                        Console.Write(matrix[rowIndex][colIndex]);
                    }
                    Console.WriteLine();
                }
            }
            else if (rotationDegrees == 270)
            {
                for (int colIndex = maxLength - 1; colIndex >= 0; colIndex--)
                {
                    for (int rowIndex = 0; rowIndex < matrix.Count; rowIndex++)
                    {
                        Console.Write(matrix[rowIndex][colIndex]);
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void RearrangeMatrix(int maxLength, List<List<char>> matrix)
        {
            for (int rowIndex = 0; rowIndex < matrix.Count; rowIndex++)
            {
                if (matrix[rowIndex].Count < maxLength)
                {
                    int count = maxLength - matrix[rowIndex].Count;

                    for (int i = 0; i < count; i++)
                    {
                        matrix[rowIndex].Add(' ');
                    }
                }
            }
        }

        public static void FillMatrix(ref int maxLength, List<List<char>> matrix, ref string currentLine)
        {
            while (currentLine != "END")
            {
                if (currentLine.Length > maxLength)
                {
                    maxLength = currentLine.Length;
                }
                matrix.Add(currentLine.ToList());

                currentLine = Console.ReadLine();
            }
        }
    }
}
