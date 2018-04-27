using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string command = Console.ReadLine();

        List<string> args = command
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .ToList();
        
        args.RemoveAt(0);
        
        ListyIterator<string> iterator = null;
        
        iterator = new ListyIterator<string>(args);

        while (command != "END")
        {
            switch (command)
            {
                case "Move":
                    Console.WriteLine(iterator.Move()); break;

                case "HasNext":
                    Console.WriteLine(iterator.HasNext()); break;

                case "Print":
                    try
                    {
                        iterator.Print();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "PrintAll":
                    iterator.PrintAll(); break;
            }

            command = Console.ReadLine();
        }
    }
}

