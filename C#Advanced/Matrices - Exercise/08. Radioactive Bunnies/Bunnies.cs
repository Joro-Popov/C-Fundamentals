using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Bunnies
{
    
    public static void Main(string[] args)
    {
        string[] dimensions = Console.ReadLine().Split();
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);
        char[][] Lair = new char[rows][];

        FillMatrix(rows, Lair);

        int playerRow = GetPlayerRow(Lair);
        int playerCol = Array.IndexOf(Lair[playerRow], 'P');
        Lair[playerRow][playerCol] = '.';

        string directions = Console.ReadLine();

        foreach (var move in directions)
        {
            int oldPlayerRow = playerRow;
            int oldPLayerCol = playerCol;

            switch (move)
            {
                case 'U': playerRow--; break;
                case 'D': playerRow++; break;
                case 'L': playerCol--; break;
                case 'R': playerCol++; break;
            }

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    if (Lair[rowIndex][colIndex] == 'B')
                    {

                    }
                }
            }
        }
    }

    public static int GetPlayerRow(char[][] Lair)
    {
        int index = 0;

        for (int rowIndex = 0; rowIndex < Lair.Length; rowIndex++)
        {
            if (Lair[rowIndex].Contains('P'))
            {
                index = rowIndex;
                
            }
        }
        return index;
    }
    public static void FillMatrix(int rows, char[][] Lair)
    {
        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            string lairRow = Console.ReadLine();

            Lair[rowIndex] = lairRow.ToCharArray();
        }
    }
}
