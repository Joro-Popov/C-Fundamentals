using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Crypto_Master
{
    public class Program
    {
        public static void Main()
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            Queue<int> numbers = new Queue<int>(inputNumbers);
            List<List<int>> sequences = new List<List<int>>();

            for (int index = 1; index < inputNumbers.Length; index++)
            {
                int currentStep = index;

                for (int sIndex = 0; sIndex < index; sIndex += currentStep)
                {

                }
            }
        }
    }
}
