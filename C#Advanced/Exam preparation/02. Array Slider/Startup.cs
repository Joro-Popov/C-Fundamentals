using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _02._Array_Slider
{
    public class Startup
    {
        public static void Main()
        {
            List<BigInteger> sequence = Console.ReadLine()
                .Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(BigInteger.Parse)
                .ToList();

            string command;
            int startIndex = 0;

            while ((command = Console.ReadLine()) != "stop")
            {
                List<string> arguments = command
                    .Split(new char[] { ' ',}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                int offset = int.Parse(arguments[0]) % sequence.Count;
                string operation = arguments[1];
                int operand = int.Parse(arguments[2]);

                if (offset < 0)
                {
                    offset += sequence.Count;
                }
                startIndex = (startIndex + offset) % sequence.Count;

                switch (operation)
                {
                    case "&": sequence[startIndex] &= operand; break;
                    case "|": sequence[startIndex] |= operand; break;
                    case "^": sequence[startIndex] ^= operand; break;
                    case "+": sequence[startIndex] += operand; break;
                    case "-": sequence[startIndex] -= operand; break;
                    case "*": sequence[startIndex] *= operand; break;
                    case "/": sequence[startIndex] /= operand; break;
                }
                if (sequence[startIndex] < 0)
                {
                    sequence[startIndex] = 0;
                }
            }

            Console.WriteLine($"[{string.Join(", ",sequence)}]");
        }
    }
}
