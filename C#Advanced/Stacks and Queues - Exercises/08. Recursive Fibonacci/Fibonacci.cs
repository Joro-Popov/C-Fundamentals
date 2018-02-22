using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Recursive_Fibonacci
{
    class Program
    {
        public static long[] memoaized = new long[51];

        static long Fib(int n)
        {
            if (n <= 2)
            {
                return 1;
            }
            if (memoaized[n] != -1)
            {
                return memoaized[n];
            }
            else
            {
                memoaized[n] = Fib(n - 1) + Fib(n - 2);
                return memoaized[n];
            }
        }
        static void Main(string[] args)
        {
            int fibonacciNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < 51; i++)
            {
                memoaized[i] = -1;
            }

            Console.WriteLine(Fib(fibonacciNumber));
        }
    }
}
