using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Jedi_Galaxy
{
    public class Startup
    {
        public static void FillGalaxy(int rows, int cols, int[][] galaxy)
        {
            int number = 0;

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    galaxy[rowIndex][colIndex] = number;
                    number++;
                }
            }
        }
        
        public static void Main()
        {
            List<int> galaxyDimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int rows = galaxyDimensions[0];
            int cols = galaxyDimensions[1];
            int[][] galaxy = new int[rows][];

            galaxy = galaxy.Select(w => w = new int[cols]).ToArray();
            FillGalaxy(rows, cols, galaxy);

            string command;
            long collectedStars = 0l;

            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                List<int> IvoCoordinates = command
                    .Split()
                    .Select(int.Parse)
                    .ToList();

                List<int> EvilCoordinates = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();

                int IvoRow = IvoCoordinates[0];
                int IvoCol = IvoCoordinates[1];
                int EvilRow = EvilCoordinates[0];
                int EvilCol = EvilCoordinates[1];

                while (EvilRow >= 0 && EvilCol >= 0)
                {
                    if (EvilRow >= 0 && EvilCol >= 0 && EvilRow < rows && EvilCol < cols)
                    {
                        galaxy[EvilRow][EvilCol] = 0;
                    }
                    EvilRow--;
                    EvilCol--;
                }

                while (IvoRow >=0 && IvoCol < cols)
                {
                    if (IvoRow >= 0 && IvoCol >= 0 && IvoRow < rows && IvoCol < cols)
                    {
                        collectedStars += galaxy[IvoRow][IvoCol];
                    }
                    IvoRow--;
                    IvoCol++;
                }
            }

            Console.WriteLine(collectedStars);
        }
        
    }
}
