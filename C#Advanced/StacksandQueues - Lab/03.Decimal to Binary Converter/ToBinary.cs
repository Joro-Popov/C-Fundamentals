using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03.Decimal_to_Binary_Converter
{
    public class ToBinary
    {
        public static void Main()
        {
            int inputNumber = int.Parse(Console.ReadLine());
            Stack<int> binaryRepresentation = new Stack<int>();

            if (inputNumber == 0 || inputNumber == 1)
            {
                Console.WriteLine(inputNumber);
                return;
            }

            while (inputNumber > 0)
            {
                binaryRepresentation.Push(inputNumber % 2);
                inputNumber /= 2;
            }

            while (binaryRepresentation.Count > 0)
            {
                Console.Write(binaryRepresentation.Pop());
            }
            Console.WriteLine();
        }
    }
}
