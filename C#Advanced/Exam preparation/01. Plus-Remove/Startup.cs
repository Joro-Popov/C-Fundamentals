using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Plus_Remove
{
    public class Startup
    {
        public static List<List<char>> Creatematrix()
        {
            List<List<char>> matrix = new List<List<char>>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                matrix.Add(command.ToList());
            }

            return matrix;
        }
        public static void Print(List<List<char>> matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine($"{string.Join("",row)}");
            }
        }
        public static List<List<int>> GetPossitions(List<List<char>>matrix)
        {
            List<List<int>> positions = new List<List<int>>();
            
            for (int rowIndex = 1; rowIndex < matrix.Count - 1; rowIndex++)
            {
                for (int colIndex = 1; colIndex < matrix[rowIndex].Count - 1; colIndex++)
                {
                    char current = char.ToLower(matrix[rowIndex][colIndex]);

                    if (colIndex < matrix[rowIndex - 1].Count && colIndex < matrix[rowIndex + 1].Count)
                    {
                        if (char.ToLower(matrix[rowIndex - 1][colIndex]) == current &&
                           char.ToLower(matrix[rowIndex + 1][colIndex]) == current &&
                           char.ToLower(matrix[rowIndex][colIndex - 1]) == current &&
                           char.ToLower(matrix[rowIndex][colIndex + 1]) == current)
                        {
                            List<int> currentPossitions = new List<int>
                        {
                            rowIndex,
                            colIndex
                        };
                            positions.Add(currentPossitions);
                        }
                    }
                   
                }
            }
            return positions;
        }
        public static List<List<char>> RemovePlusShape(List<List<char>> matrix,List<int> positions)
        {
            int row = positions[0];
            int col = positions[1];

            matrix[row][col] = '\u0000';
            matrix[row - 1][col] = '\u0000';
            matrix[row + 1][col] = '\u0000';
            matrix[row][col - 1] = '\u0000';
            matrix[row][col + 1] = '\u0000';

            return matrix;
        }
        public static void Main()
        {
            List<List<char>> matrix = Creatematrix();
            List<List<int>> possitions = new List<List<int>>();

            if (matrix.Count < 3)
            {
                Print(matrix);
                return;
            }

            foreach (var pair in GetPossitions(matrix))
            {
                List<int> current = pair;
                RemovePlusShape(matrix, current);
            }

            foreach (var row in matrix)
            {
                List<char> current = row.Where(c => c != '\u0000').ToList();
                Console.WriteLine($"{string.Join("",current)}");
            }
        }

    }
}
