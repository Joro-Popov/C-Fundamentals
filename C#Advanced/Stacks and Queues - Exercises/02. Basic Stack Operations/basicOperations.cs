using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Stack_Operations
{
    public class BasicOperations
    {
        public static void Main()
        {
            int[] arguments = Console.ReadLine()
                .Split(new char[] { ' ' }
                , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }
                , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> elements = new Stack<int>();

            int elementsToPush = arguments[0];
            int elementsToPop = arguments[1];
            int elementToLookFor = arguments[2];

            Push(numbers, elements, elementsToPush);
            Pop(numbers, elements, elementsToPop);
            LookForElement(elements, elementToLookFor);
        }

        public static void LookForElement(Stack<int> elements, int elementToLookFor)
        {
            if (elements.Contains(elementToLookFor)) Console.WriteLine("true");
            else if (elements.Count > 0) Console.WriteLine(elements.Min());
            else Console.WriteLine(0);
            
        }

        public static void Pop(int[] numbers, Stack<int> elements, int elementsToPop)
        {
            if (elementsToPop > numbers.Length)
            {
                elements.Clear();
            }
            else
            {
                for (int i = 0; i < elementsToPop; i++)
                {
                    elements.Pop();
                }
            }
        }

        public static void Push(int[] numbers, Stack<int> elements, int elementsToPush)
        {
            int count = Math.Min(elementsToPush, numbers.Length);

            for (int i = 0; i < count; i++)
            {
                elements.Push(numbers[i]);
            }
        }
    }
}
