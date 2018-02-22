using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bunker_Buster
{
    public class Startup
    {
        public static bool IsinField(int row, int col,int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }
        public static void DamageAdjacentCells(int rows, int cols, long[][] field, int bombRow, int bombCol, int halfForce)
        {
            for (int rowIndex = bombRow - 1; rowIndex <= bombRow + 1; rowIndex++)
            {
                for (int colIndex = bombCol - 1; colIndex <= bombCol + 1; colIndex++)
                {
                    if (IsinField(rowIndex, colIndex, rows, cols))
                    {
                        if (rowIndex == bombRow && colIndex == bombCol)
                        {
                            continue;
                        }
                        field[rowIndex][colIndex] -= halfForce;
                    }
                }
            }
        }
        public static void Main()
        {
            List<int> fieldDimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int rows = fieldDimensions[0];
            int cols = fieldDimensions[1];

            long[][] field = new long[rows][];

            field = field
                .Select(r => r = new long[cols])
                .Select(r => r = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray())
                .ToArray();

            string command;
            while ((command = Console.ReadLine()) != "cease fire!")
            {
                List<char> bombDetails = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToList();

                int bombRow = int.Parse(bombDetails[0].ToString());
                int bombCol = int.Parse(bombDetails[1].ToString());
                int fullForce = bombDetails[2];
                int halfForce = (int)Math.Ceiling(fullForce / 2m);

                field[bombRow][bombCol] -= fullForce;
                DamageAdjacentCells(rows, cols, field, bombRow, bombCol, halfForce);

            }
            
            long destroyedCount = 0;

            foreach (var row in field)
            {
                destroyedCount += row.Where(w => w <= 0).ToArray().Length;
            }
            decimal percentage = (destroyedCount * 100.0m) / (rows * cols);
            percentage = Math.Round(percentage,1);

            Console.WriteLine($"Destroyed bunkers: {destroyedCount}");
            Console.WriteLine($"Damage done: {percentage} %");
        }
        
    }
}
