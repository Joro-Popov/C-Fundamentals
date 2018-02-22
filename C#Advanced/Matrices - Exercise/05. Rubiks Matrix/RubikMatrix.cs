using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RubikMatrix
{
    public static void FillRubikCube(int rows, int cols, int[][] RubikCube)
    {
        int currentNumber = 1;

        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            RubikCube[rowIndex] = new int[cols];

            for (int colIndex = 0; colIndex < cols; colIndex++)
            {
                RubikCube[rowIndex][colIndex] = currentNumber;
                currentNumber++;
            }
        }
    }

    public static void MoveDown(int[][] RubikCube, long moves, int rows, int rowCol)
    {
        Queue<int> temp = new Queue<int>();
        
        for (int i = rows - 1; i >= 0; i--)
        {
            temp.Enqueue(RubikCube[i][rowCol]);
        }
        
        Rotate(moves, temp);
        
        for (int i = rows - 1; i >= 0; i--)
        {
            RubikCube[i][rowCol] = temp.Dequeue();
        }
    }

    private static void Rotate(long moves, Queue<int> temp)
    {
        for (long i = 0; i < moves; i++)
        {
            int currentNum = temp.Dequeue();
            temp.Enqueue(currentNum);
        }
    }

    public static void MoveUp(int[][] RubikCube, long moves, int rows, int rowCol)
    {
        Queue<int> temp = new Queue<int>();
        
        for (int i = 0; i < rows; i++)
        {
            temp.Enqueue(RubikCube[i][rowCol]);
        }
        
        Rotate(moves, temp);
        
        for (int i = 0; i < rows; i++)
        {
            RubikCube[i][rowCol] = temp.Dequeue();
        }
    }
    public static void MoveLeft(int[][] RubikCube, int rowCol, long moves, int cols)
    {
        Queue<int> temp = new Queue<int>(RubikCube[rowCol]);
        
        Rotate(moves, temp);
        
        for (int i = 0; i < cols; i++)
        {
            RubikCube[rowCol][i] = temp.Dequeue();
        }
    }

    public static void MoveRight(int[][] RubikCube, int rowCol, long moves, int cols)
    {
        Queue<int> temp = new Queue<int>(RubikCube[rowCol].Reverse());
        
        Rotate(moves, temp);
        
        for (int i = cols - 1; i >= 0; i--)
        {
            RubikCube[rowCol][i] = temp.Dequeue();
        }
    }

    public static void Rearrange(int[][] RubikCube)
    {
        for (int rowIndex = 0; rowIndex < RubikCube.Length; rowIndex++)
        {
            for (int colIndex = 0; colIndex < RubikCube[rowIndex].Length; colIndex++)
            {
                int initValue = rowIndex * RubikCube[rowIndex].Length + (colIndex + 1);
                int currentValue = RubikCube[rowIndex][colIndex];

                if (initValue != currentValue)
                {
                    for (int index = 0; index < RubikCube.Length; index++)
                    {
                        int[] currentArray = RubikCube[index];
                        int currentIndex = Array.IndexOf(currentArray, initValue);

                        if (currentIndex > -1)
                        {
                            Console.WriteLine($"Swap {(rowIndex, colIndex)} with {(index, currentIndex)}");

                            RubikCube[index][currentIndex] = currentValue;
                            RubikCube[rowIndex][colIndex] = initValue;
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No swap required");
                }
            }
        }
    }

    public static void Main()
    {
        List<int> matrixDimensions = Console.ReadLine()
            .Split(new char[] { ' ' }
            ,StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        int rows = matrixDimensions[0];
        int cols = matrixDimensions[1];

        int[][] RubikCube = new int[rows][];

        FillRubikCube(rows, cols, RubikCube);

        int numberOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCommands; i++)
        {
            List<string> commands = Console.ReadLine()
                .Split(new char[] { ' ' }
                ,StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int rowCol = int.Parse(commands[0]);
            string direction = commands[1];
            long moves = long.Parse(commands[2]);

            if (direction == "up")
            {
                MoveUp(RubikCube, moves, rows, rowCol);
            }
            else if (direction == "down")
            {
                MoveDown(RubikCube, moves, rows, rowCol);
            }
            else if (direction == "left")
            {
                MoveLeft(RubikCube, rowCol, moves, cols);
            }
            else if (direction == "right")
            {
                MoveRight(RubikCube, rowCol, moves, cols);
            }
        }

        Rearrange(RubikCube);
    }

    
}
