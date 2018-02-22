using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Knight_Game
{
    public class Knight
    {
        public int Damage { get; set; }
        public int RowIndex { get; set; }
        public int ColIndex { get; set; }

        public Knight(int rowIndex, int colIndex, int damage)
        {
            Damage = damage;
            RowIndex = rowIndex;
            ColIndex = colIndex;
        }
    }

    public class Startup
    {
        public static void Main()
        {
            int boardSize = int.Parse(Console.ReadLine());
            if (boardSize <= 2)
            {
                Console.WriteLine(0);
                return;
            }
            char[][] board = new char[boardSize][];
            
            board = board
                .Select(w => w = new char[boardSize])
                .Select(w => w = Console.ReadLine().ToCharArray())
                .ToArray();

            Knight mostDangerous = new Knight(0, 0, 0);

            int removed = 0;

            while (true)
            {
                for (int rowIndex = 0; rowIndex < boardSize; rowIndex++)
                {
                    char[] currentRow = board[rowIndex];
                    int knightIndex = Array.IndexOf(currentRow, 'K');

                    while (knightIndex != -1)
                    {
                        Knight currentKnight = new Knight(rowIndex, knightIndex, 0);

                        if (rowIndex - 2 >= 0 && knightIndex - 1 >= 0 &&
                            board[rowIndex - 2][knightIndex - 1] == 'K')
                        {
                            currentKnight.Damage++;
                        }
                        if (rowIndex - 2 >= 0 && knightIndex + 1 < boardSize &&
                            board[rowIndex - 2][knightIndex + 1] == 'K')
                        {
                            currentKnight.Damage++;
                        }
                        if (rowIndex - 1 >= 0 && knightIndex + 2 < boardSize &&
                            board[rowIndex - 1][knightIndex + 2] == 'K')
                        {
                            currentKnight.Damage++;
                        }
                        if (rowIndex + 1 < boardSize && knightIndex + 2 < boardSize &&
                            board[rowIndex + 1][knightIndex + 2] == 'K')
                        {
                            currentKnight.Damage++;
                        }
                        if (rowIndex + 2 < boardSize && knightIndex + 1 < boardSize &&
                            board[rowIndex + 2][knightIndex + 1] == 'K')
                        {
                            currentKnight.Damage++;
                        }
                        if (rowIndex + 2 < boardSize && knightIndex - 1 >= 0 &&
                            board[rowIndex + 2][knightIndex - 1] == 'K')
                        {
                            currentKnight.Damage++;
                        }
                        if (rowIndex - 1 >= 0 && knightIndex - 2 >= 0 &&
                            board[rowIndex - 1][knightIndex - 2] == 'K')
                        {
                            currentKnight.Damage++;
                        }
                        if (rowIndex + 1 < boardSize && knightIndex - 2 >= 0 &&
                            board[rowIndex + 1][knightIndex - 2] == 'K')
                        {
                            currentKnight.Damage++;
                        }

                        if (currentKnight.Damage > mostDangerous.Damage)
                        {
                            mostDangerous = currentKnight;
                        }

                        knightIndex = Array.IndexOf(currentRow, 'K', knightIndex + 1);
                    }
                }

                if (mostDangerous.Damage != 0)
                {
                    board[mostDangerous.RowIndex][mostDangerous.ColIndex] = '0';
                    removed++;
                    mostDangerous.Damage = 0;
                }
                else
                {
                    Console.WriteLine(removed);
                    return;
                }
            }
        }

    }
}
