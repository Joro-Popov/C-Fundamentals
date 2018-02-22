using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_Element
{
    public class MaxElement
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            int maxNum = 1;

            Stack<int> numbers = new Stack<int>();
            Stack<int> maxNumbers = new Stack<int>();

            for (int index = 0; index < count; index++)
            {
                int[] input = Console.ReadLine()
                    .Split(new char[] { ' ' }
                    , StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int type = input[0];

                if (type == 1)
                {
                    int numberToPush = input[1];

                    if (numberToPush > maxNum)
                    {
                        maxNum = numberToPush;
                        maxNumbers.Push(maxNum);
                    }
                    numbers.Push(numberToPush);
                }
                else if (type == 2)
                {
                    if (numbers.Count > 0 )
                    {
                        if (numbers.Peek() == maxNumbers.Peek() && maxNumbers.Count > 0)
                        {
                            maxNumbers.Pop();

                            if (maxNumbers.Count > 0)
                            {
                                maxNum = maxNumbers.Peek();
                            }
                            else
                            {
                                maxNum = 1;
                            }
                        }
                        numbers.Pop();
                    }
                    
                }
                else
                {
                    Console.WriteLine(maxNumbers.Peek());
                }
            }
        }
    }
}
