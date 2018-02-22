using System;
using System.Linq;

namespace _04.Pascal_Triangle
{
    public class PascalTriangle
    {
        public static void Main()
        {
            int triangleSize = int.Parse(Console.ReadLine());

            long[][] PascalTriangle = new long[triangleSize][];

            PascalTriangle = PascalTriangle
                .Select((r, i) => r = new long[++i])
                .ToArray();

            PascalTriangle[0][0] = 1;
            
            for (int rowIndex = 1; rowIndex < PascalTriangle.Length; rowIndex++)
            {
                PascalTriangle[rowIndex][0] = 1;
                PascalTriangle[rowIndex][PascalTriangle[rowIndex].Length - 1] = 1;
            }

            for (int rowIndex = 1; rowIndex < triangleSize - 1; rowIndex++)
            {
                long[] currentRow = PascalTriangle[rowIndex];
                long[] nextRow = PascalTriangle[rowIndex + 1];

                for (int i = 1; i < currentRow.Length; i++)
                {
                    long sum = currentRow[i - 1] + currentRow[i];
                    nextRow[i] = sum;
                }
            }

            foreach (var row in PascalTriangle)
            {
                Console.WriteLine(string.Join(" ",row));
            }
        }
    }
}
