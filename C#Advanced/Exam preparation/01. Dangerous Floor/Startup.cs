using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Dangerous_Floor
{
    public class Startup
    {
        public static void Main()
        {
            char[][] board = new char[8][];

            board = board
                .Select(w => w = new char[8])
                .Select(w => w = Console.ReadLine().Split(',').Select(char.Parse).ToArray())
                .ToArray();

            string moves;

            while ((moves = Console.ReadLine()) != "END")
            {
                char pieceToMove = moves[0];
                int currentRow = int.Parse(moves[1].ToString());
                int currentCol = int.Parse(moves[2].ToString());
                int finalRow = int.Parse(moves[4].ToString());
                int finalCol = int.Parse(moves[5].ToString());

                switch (pieceToMove)
                {
                    case 'K': MoveKing(board, pieceToMove, currentRow, currentCol, finalRow, finalCol); break;
                    case 'R': MoveRook(board, pieceToMove, currentRow, currentCol, finalRow, finalCol); break;
                    case 'B': MoveBishop(board, pieceToMove, currentRow, currentCol, finalRow, finalCol); break;
                    case 'Q': MoveQueen(board, pieceToMove, currentRow, currentCol, finalRow, finalCol); break;
                    case 'P': MovePawn(board, pieceToMove, currentRow, currentCol, finalRow, finalCol); break;
                }
               
            }
        }

        public static void MovePawn(char[][] board, char pieceToMove, int currentRow, int currentCol, int finalRow, int finalCol)
        {
            if (board[currentRow][currentCol] == pieceToMove)
            {
                if (!(finalRow != currentRow - 1 || finalCol != currentCol))
                {
                    if (finalRow >= 0 && finalRow < 8 && finalCol >= 0 && finalCol < 8)
                    {
                        board[currentRow][currentCol] = 'x';
                        board[finalRow][finalCol] = pieceToMove;
                    }
                    else
                    {
                        Console.WriteLine($"Move go out of board!");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid move!");
                }
            }
            else
            {
                Console.WriteLine($"There is no such a piece!");
            }
        }
        public static void MoveQueen(char[][] board, char pieceToMove, int currentRow, int currentCol, int finalRow, int finalCol)
        {
            if (board[currentRow][currentCol] == pieceToMove)
            {
                if (Math.Abs(finalRow - currentRow) == Math.Abs(finalCol - currentCol) || (finalRow == currentRow || finalCol == currentCol))
                {
                    if (finalRow >= 0 && finalRow < 8 && finalCol >= 0 && finalCol < 8)
                    {
                        board[currentRow][currentCol] = 'x';
                        board[finalRow][finalCol] = pieceToMove;
                    }
                    else
                    {
                        Console.WriteLine($"Move go out of board!");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid move!");
                }
            }
            else
            {
                Console.WriteLine($"There is no such a piece!");
            }
        }
        public static void MoveBishop(char[][] board, char pieceToMove, int currentRow, int currentCol, int finalRow, int finalCol)
        {
            if (board[currentRow][currentCol] == pieceToMove)
            {
                if (Math.Abs(finalRow - currentRow) == Math.Abs(finalCol - currentCol))
                {
                    if (finalRow >= 0 && finalRow < 8 && finalCol >= 0 && finalCol < 8)
                    {
                        board[currentRow][currentCol] = 'x';
                        board[finalRow][finalCol] = pieceToMove;
                    }
                    else
                    {
                        Console.WriteLine($"Move go out of board!");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid move!");
                }
            }
            else
            {
                Console.WriteLine($"There is no such a piece!");
            }
        }
        public static void MoveRook(char[][] board, char pieceToMove, int currentRow, int currentCol, int finalRow, int finalCol)
        {
            if (board[currentRow][currentCol] == pieceToMove)
            {
                if (finalRow == currentRow || finalCol == currentCol)
                {
                    if ((finalRow >= 0 && finalRow < 8 && finalCol >= 0 && finalCol < 8))
                    {
                        board[currentRow][currentCol] = 'x';
                        board[finalRow][finalCol] = pieceToMove;
                    }
                    else
                    {
                        Console.WriteLine($"Move go out of board!");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid move!");
                }
            }
            else
            {
                Console.WriteLine($"There is no such a piece!");
            }
        }
        public static void MoveKing(char[][] board, char pieceToMove, int currentRow, int currentCol, int finalRow, int finalCol)
        {
            if (board[currentRow][currentCol] == pieceToMove)
            {
                if ((finalRow >= currentRow - 1) && (finalRow <= currentRow + 1) &&
                    (finalCol >= currentCol - 1) && (finalCol <= currentCol + 1))
                {
                    if (finalRow >= 0 && finalRow < 8 && finalCol >= 0 && finalCol < 8)
                    {
                        board[currentRow][currentCol] = 'x';
                        board[finalRow][finalCol] = pieceToMove;
                    }
                    else
                    {
                        Console.WriteLine($"Move go out of board!");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid move!");
                }
            }
            else
            {
                Console.WriteLine($"There is no such a piece!");
            }
        }
    }
}
