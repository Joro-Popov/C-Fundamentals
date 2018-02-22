using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05.Hot_Potato
{
    public class HotPotato
    {
        public static void Main()
        {
            string[] childrenInput = Console.ReadLine()
                .Split(new char[] { ' ' }
                , StringSplitOptions.RemoveEmptyEntries);

            int toss = int.Parse(Console.ReadLine());

            Queue<string> childrens = new Queue<string>(childrenInput);

            while (childrens.Count > 1)
            {
                for (int index = 1; index < toss; index++)
                {
                    string currentChild = childrens.Dequeue();
                    childrens.Enqueue(currentChild);
                }
                Console.WriteLine($"Removed {childrens.Dequeue()}");
            }
            Console.WriteLine($"Last is {childrens.Dequeue()}");
        }
    }
}
