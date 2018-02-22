using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Lego
{
    public static void CreateJaggeLists(int rowsCount, List<List<long>> primeJag, List<List<long>> secondJag)
    {
        for (int rowIndex = 0; rowIndex < rowsCount * 2; rowIndex++)
        {
            List<long> input = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ' }
                , StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            if (rowIndex < rowsCount)
            {
                primeJag.Add(input);
            }
            else
            {
                secondJag.Add(input);
            }
        }
    }
    
    public static void ReverseSecondJag(List<List<long>> secondJag)
    {
        for (int rowIndex = 0; rowIndex < secondJag.Count; rowIndex++)
        {
            secondJag[rowIndex].Reverse();
        }
    }

    public static void FitJags(List<List<long>> primeJag, List<List<long>> secondJag)
    {
        for (int rowIndex = 0; rowIndex < primeJag.Count; rowIndex++)
        {
            primeJag[rowIndex].AddRange(secondJag[rowIndex]);
        }
    }

    public static bool FitPerfect(List<List<long>> primeJag)
    {
        int rowSize = primeJag[0].Count;

        for (int rowIndex = 0; rowIndex < primeJag.Count; rowIndex++)
        {
            if (primeJag[rowIndex].Count != rowSize)
            {
                return false;
            }
        }

        return true;
    }

    public static void PrintNumberOfCells(List<List<long>> primeJag)
    {
        int totalCells = 0;

        for (int rowIndex = 0; rowIndex < primeJag.Count; rowIndex++)
        {
            totalCells += primeJag[rowIndex].Count;
        }

        Console.WriteLine($"The total number of cells is: {totalCells}");
    }

    public static void PrintMatrix(List<List<long>> primeJag)
    {
        for (int rowIndex = 0; rowIndex < primeJag.Count; rowIndex++)
        {
            Console.WriteLine($"[{string.Join(", ", primeJag[rowIndex])}]");
        }
    }

    public static void Main()
    {
        int rowsCount = int.Parse(Console.ReadLine());

        List<List<long>> primeJag = new List<List<long>>();
        List<List<long>> secondJag = new List<List<long>>();

        CreateJaggeLists(rowsCount, primeJag, secondJag);

        ReverseSecondJag(secondJag);

        FitJags(primeJag, secondJag);

        if (FitPerfect(primeJag))
        {
            PrintMatrix(primeJag);
        }
        else
        {
            PrintNumberOfCells(primeJag);
        }
    }
}
