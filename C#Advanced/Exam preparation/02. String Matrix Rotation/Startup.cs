using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._String_Matrix_Rotation
{
    public class Startup
    {
        public static void PadMissingSpaces(List<List<char>> matrix, int longest)
        {
            for (int index = 0; index < matrix.Count; index++)
            {
                if (matrix[index].Count < longest)
                {
                    int diff = longest - matrix[index].Count;
                    string spaces = new string(' ', diff);
                    matrix[index].AddRange(spaces);
                }
            }
        }
        public static void Print_0_Or_360(List<List<char>>matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("",row));
            }
        }
        public static void Print_90(List<List<char>> matrix,int longest)
        {
            for (int colIndex = 0; colIndex < longest; colIndex++)
            {
                for (int rowIndex = matrix.Count - 1; rowIndex >= 0; rowIndex--)
                {
                    Console.Write(matrix[rowIndex][colIndex]);
                }
                Console.WriteLine();
            }
        }
        public static void Print_180(List<List<char>> matrix)
        {
            for (int rowIndex = matrix.Count - 1; rowIndex >= 0; rowIndex--)
            {
                matrix[rowIndex].Reverse();
                Console.WriteLine(string.Join("",matrix[rowIndex]));
            }
        }
        public static void Print_270(List<List<char>> matrix,int longest)
        {
            for (int colIndex = longest - 1; colIndex >= 0; colIndex--)
            {
                for (int rowIndex = 0; rowIndex < matrix.Count; rowIndex++)
                {
                    Console.Write(matrix[rowIndex][colIndex]);
                }
                Console.WriteLine();
            }
        }
        public static void Main()
        {
            List<string> tokens = Console.ReadLine()
                .Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int number = int.Parse(tokens[1]);
            string input;
            List<List<char>> matrix = new List<List<char>>();

            while ((input = Console.ReadLine()) != "END")
            {
                matrix.Add(input.ToList());
            }

            int longest = matrix.Max(w => w.Count);
            PadMissingSpaces(matrix, longest);

            int degrees = number % 360;

            if (degrees == 0 || degrees == 360)
            {
                Print_0_Or_360(matrix);
            }
            else if (degrees == 90)
            {
                Print_90(matrix, longest);
            }
            else if (degrees == 180)
            {
                Print_180(matrix);
            }
            else if (degrees == 270)
            {
                Print_270(matrix, longest);
            }
        }
        
    }
}
