using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Snakes
{
    public static void FillMatrix(string snake, int rows, int cols, char[][] stairsMatrix)
    {
        for (int i = 0; i < stairsMatrix.Length; i++)
        {
            stairsMatrix[i] = new char[cols];
        }

        Queue<char> snakeElements = new Queue<char>(snake);
        int currentRow = 0;

        for (int rowIndex = rows - 1; rowIndex >= 0; rowIndex--)
        {
            if (currentRow % 2 == 0)
            {
                for (int colIndex = cols - 1; colIndex >= 0; colIndex--)
                {
                    if (snakeElements.Count == 0)
                    {
                        snakeElements = new Queue<char>(snake);
                    }

                    char currentChar = snakeElements.Dequeue();

                    stairsMatrix[rowIndex][colIndex] = currentChar;
                }
                currentRow++;
            }
            else
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    if (snakeElements.Count == 0)
                    {
                        snakeElements = new Queue<char>(snake);
                    }

                    char currentChar = snakeElements.Dequeue();

                    stairsMatrix[rowIndex][colIndex] = currentChar;
                }
                currentRow++;
            }
        }
    }

    public static bool IsInside(int Xc, int Yc, int Xp, int Yp, int radius)
    {
        int expression = (Xp - Xc) * (Xp - Xc) + (Yp - Yc) * (Yp - Yc);

        if (Math.Sqrt(expression) <= radius)
        {
            return true;
        }
        return false;
    }

    public static void DestroySymbolsInRadius(int rows, int cols, int impactRow, int impactColumn, int radius, char[][] stairsMatrix)
    {
        int Xc = impactRow;
        int Yc = impactColumn;

        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            for (int colIndex = 0; colIndex < cols; colIndex++)
            {
                int Xp = rowIndex;
                int Yp = colIndex;

                if (IsInside(Xc, Yc, Xp, Yp, radius))
                {
                    stairsMatrix[rowIndex][colIndex] = ' ';
                }
            }
        }
    }

    public static Stack<char> Rearrange(int rows, int colIndex, char[][] stairsMatrix, Stack<char> rearranged)
    {
        for (int rowIndex = rows - 1; rowIndex >= 0; rowIndex--)
        {
            char currentChar = stairsMatrix[rowIndex][colIndex];

            rearranged.Push(currentChar);
        }

        char[] token = rearranged.ToArray();
        token = token.Where(c => c != ' ').ToArray();

        rearranged = new Stack<char>(token);
        return rearranged;
    }

    public static void RefillMatrix(int rows, int cols, char[][] stairsMatrix)
    {
        for (int colIndex = 0; colIndex < cols; colIndex++)
        {
            Stack<char> rearranged = new Stack<char>();
            rearranged = Rearrange(rows, colIndex, stairsMatrix, rearranged);

            for (int rowIndex = rows - 1; rowIndex >= 0; rowIndex--)
            {
                char currentChar = ' ';

                if (rearranged.Count > 0)
                {
                    currentChar = rearranged.Pop();
                }

                stairsMatrix[rowIndex][colIndex] = currentChar;
            }
        }
    }

    public static void Printmatrix(int rows, char[][] stairsMatrix)
    {
        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            char[] currentArray = stairsMatrix[rowIndex];

            Console.WriteLine(string.Join("", currentArray));
        }
    }

    public static void Main(string[] args)
    {
        List<int> dimensions = Console.ReadLine()
            .Split(new char[] { ' ' }
            , StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        string snake = Console.ReadLine();

        List<int> parameters = Console.ReadLine()
            .Split(new char[] { ' ' }
            , StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        int rows = dimensions[0];
        int cols = dimensions[1];

        int impactRow = parameters[0];
        int impactColumn = parameters[1];
        int radius = parameters[2];

        char[][] stairsMatrix = new char[rows][];

        FillMatrix(snake, rows, cols, stairsMatrix);

        DestroySymbolsInRadius(rows, cols, impactRow, impactColumn, radius, stairsMatrix);

        RefillMatrix(rows, cols, stairsMatrix);

        Printmatrix(rows, stairsMatrix);
    }
    
}
