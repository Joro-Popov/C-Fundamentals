using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Basic_Queue_Operations
{
    public class BasicQueue
    {
        public static void Main()
        {
            int[] arguments = Console.ReadLine()
                .Split(new char[] { ' ' }
                , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] numberSequence = Console.ReadLine()
                .Split(new char[] { ' ' }
                , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbersQueue = new Queue<int>();

            int numbersToEnqueue = arguments[0];
            int numbersToDequeue = arguments[1];
            int numberToLookFor = arguments[2];

            Enqueue(numbersToEnqueue, numberSequence, numbersQueue);
            Dequeue(numbersToDequeue, numbersQueue);
            LookFornumber(numbersQueue, numberToLookFor);
        }
        public static void LookFornumber(Queue<int> queue, int number)
        {
            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(number))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
        public static void Dequeue(int numbersToDequeue,Queue<int> numbersQueue)
        {
            if (numbersToDequeue > numbersQueue.Count)
            {
                numbersQueue.Clear();
                
            }
            else
            {
                for (int i = 0; i < numbersToDequeue; i++)
                {
                    numbersQueue.Dequeue();
                }
            }
        }
        public static void Enqueue(int numbersToEnqueue, int[]numbersSequence, Queue<int> numbersQueue)
        {
            int count = Math.Min(numbersToEnqueue, numbersSequence.Length);

            for (int i = 0; i < count; i++)
            {
                numbersQueue.Enqueue(numbersSequence[i]);
            }
        }
    }
}
