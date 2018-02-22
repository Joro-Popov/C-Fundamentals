using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Stack_Fibonacci
{
    public class StackFib
    {
        public static void Main()
        {
            int NthFib = int.Parse(Console.ReadLine());
            Stack<long> FibSequence = new Stack<long>();

            if (NthFib <= 1)
            {
                Console.WriteLine(1);
                return;
            }

            FibSequence.Push(0);
            FibSequence.Push(1);

            while (FibSequence.Count <= NthFib)
            {
                long f1 = FibSequence.Pop();
                long f2 = FibSequence.Peek();

                FibSequence.Push(f1);
                FibSequence.Push(f1 + f2);
            }
            Console.WriteLine(FibSequence.Pop());
        }
    }
}
