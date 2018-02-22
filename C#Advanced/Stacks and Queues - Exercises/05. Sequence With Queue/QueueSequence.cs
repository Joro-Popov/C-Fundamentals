using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Sequence_With_Queue
{
    public class QueueSequence
    {
        public static void Main()
        {
            long S1 = long.Parse(Console.ReadLine());
            Queue<long> sequence = new Queue<long>();
            int count = 1;

            sequence.Enqueue(S1);
            Console.Write($"{S1} ");
            while (true)
            {
                long current = sequence.Dequeue();
                long S2 = current + 1;
                long S3 = (2 * current) + 1;
                long S4 = current + 2;

                sequence.Enqueue(S2);
                sequence.Enqueue(S3);
                sequence.Enqueue(S4);

                Console.Write($"{S2} ");
                count++;

                if (count == 50)
                {
                    break;
                }

                Console.Write($"{S3} ");
                count++;

                if (count == 50)
                {
                    break;
                }

                Console.Write($"{S4} ");
                count++;

                if (count == 50)
                {
                    break;
                }
            }
            Console.WriteLine();
        }
    }
}
