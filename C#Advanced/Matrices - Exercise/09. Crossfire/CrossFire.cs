using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CrossFire
{
    static void Main(string[] args)
    {
        int[] dimensions = Console.ReadLine()
            .Split(new char[] { ' ' }
            , StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int rows = dimensions[0];
        int cols = dimensions[1];
        List<List<int>> matrix = new List<List<int>>();

        FillMatrix(rows, cols, matrix);

        string[] command = Console.ReadLine().Split();

        while (string.Join(" ", command) != "Nuke it from orbit")
        {
            matrix = DestroyElements(rows, cols, matrix, command);
            command = Console.ReadLine().Split();
        }
        PrintResult(rows, matrix);
    }

    public static void PrintResult(int rows, List<List<int>> matrix)
    {
        foreach (var list in matrix)
        {
            Console.WriteLine(string.Join(" ",list));
        }
    }

    public static List<List<int>> DestroyElements(int rows, int cols, List<List<int>> matrix, string[] command)
    {
        int hitRow = int.Parse(command[0]);
        int hitCol = int.Parse(command[1]);
        int radius = int.Parse(command[2]);

        for (int colIndex = hitCol - radius; colIndex <= hitCol + radius; colIndex++)
        {
            if (IsInMatrix(hitRow, colIndex, matrix))
            {
                matrix[hitRow][colIndex] = 0;
            }
        }

        for (int rowIndex = hitRow - radius; rowIndex <= hitRow + radius; rowIndex++)
        {
            if (IsInMatrix(rowIndex, hitCol, matrix))
            {
                matrix[rowIndex][hitCol] = 0;
            }
        }


        matrix = matrix.Where(w => w.Count > 0).ToList();

        for (int rowIndex = 0; rowIndex < matrix.Count; rowIndex++)
        {
            matrix[rowIndex] = matrix[rowIndex].Where(w => w > 0).ToList();
        }
        return matrix;
    }

    private static bool IsInMatrix(int row, int col, List<List<int>> matrix)
    {
        return row >= 0 && col >= 0 && row < matrix.Count && col < matrix[row].Count;
    }

    public static void FillMatrix(int rows, int cols, List<List<int>> matrix)
    {
        int currentNum = 1;
        List<int> temp = new List<int>();

        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            for (int colIndex = 0; colIndex < cols; colIndex++)
            {
                temp.Add(currentNum);
                currentNum++;
            }
            matrix.Add(temp);
            temp = new List<int>();
        }
    }
}
