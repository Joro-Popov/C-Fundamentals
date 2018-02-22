using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Palindromes
{
    public static void Main()
    {
        List<int> input = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        int rows = input[0];
        int cols = input[1];

        char[] alphabet = new char[]
        {
            'a','b','c','d','e','f','g','h','i','j','k','l','m',
            'n','o','p','q','r','s','t','u','v','w','x','y','z'
        };

        string[][] palindromeMatrix = new string[rows][];

        for (int rowIndex = 0; rowIndex < palindromeMatrix.Length; rowIndex++)
        {
            palindromeMatrix[rowIndex] = new string[cols];
        }

        for (int rowIndex = 0; rowIndex < palindromeMatrix.Length; rowIndex++)
        {
            for (int colIndex = 0; colIndex < palindromeMatrix[rowIndex].Length; colIndex++)
            {
                string palindrome = alphabet[rowIndex].ToString() + alphabet[(rowIndex + colIndex)].ToString() + alphabet[rowIndex].ToString();
                
                Console.Write($"{palindrome} ");
            }
            Console.WriteLine();
        }
    }
}
