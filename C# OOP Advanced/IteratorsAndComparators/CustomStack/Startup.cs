using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        CustomStack<int> myStack = new CustomStack<int>();

        List<string> args = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        
        while (args[0] != "END")
        {
            switch (args[0])
            {
                case "Push":
                    args.RemoveAt(0);
                    List<int> nums = args.Select(int.Parse).ToList();

                    foreach (var num in nums)
                    {
                        myStack.Push(num);
                    }
                    break;

                case "Pop":
                    try
                    {
                        myStack.Pop(); break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
            }

            args = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        }

        for (int i = 0; i < 2; i++)
        {
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
