using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Command_Interpreter
{
    public class Startup
    {
        public static void Reverse(ref List<string> sequence, List<string> format)
        {
            List<string> tokens = new List<string>();

            int start = int.Parse(format[2]);
            int count = int.Parse(format[4]);

            if (start >=0 && start < sequence.Count && count >= 0)
            {
                if (count <= Math.Abs(start - sequence.Count))
                {
                    tokens = sequence.GetRange(start, count);
                    sequence.RemoveRange(start, count);
                    tokens.Reverse();
                    sequence.InsertRange(start, tokens);
                    return;
                }
                
            }
            Console.WriteLine($"Invalid input parameters.");
        }
        public static void Sort( ref List<string> sequence, List<string> format)
        {
            List<string> tokens = new List<string>();

            int start = int.Parse(format[2]);
            int count = int.Parse(format[4]);

            if (start >= 0 && start < sequence.Count && count >= 0)
            {
                if (count <= Math.Abs(start - sequence.Count))
                {
                    tokens = sequence.GetRange(start, count);
                    sequence.RemoveRange(start, count);
                    tokens.Sort();
                    sequence.InsertRange(start, tokens);
                    return;
                }
               
            }
            Console.WriteLine($"Invalid input parameters.");
        }
        public static void RollLeft(ref List<string> sequence, List<string> format)
        {
            int count = int.Parse(format[1]);

            for (int index = 0; index < count; index++)
            {
                string currentElement = sequence[0];
                sequence.RemoveAt(0);
                sequence.Add(currentElement);
            }
        }
        public static void RollRight(ref List<string> sequence, List<string> format)
        {
            int count = int.Parse(format[1]);

            for (int index = 0; index < count; index++)
            {
                string currentElement = sequence[sequence.Count - 1];
                sequence.RemoveAt(sequence.Count - 1);
                sequence.Insert(0, currentElement);
            }
        }
        public static void Main()
        {
            List<string> sequence = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                List<string> format = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string operation = format[0];

                switch (operation)
                {
                    case "reverse": Reverse(ref sequence,format); break;
                    case "sort": Sort(ref sequence,format); break;
                    case "rollLeft": RollLeft(ref sequence,format); break;
                    case "rollRight": RollRight(ref sequence,format); break;
                }
            }

            Console.WriteLine($"[{String.Join(", ",sequence)}]");
        }
    }
}
