using System;

public class Startup
{
    public static void PrintRow(int size,int counter)
    {
        Console.Write($"{new string(' ',size - counter)}");
        for (int i = 0; i < counter; i++)
        {
            Console.Write("* ");
        }
        Console.WriteLine();
    }
    static void Main()
    {
        int rhombusSize = int.Parse(Console.ReadLine());
        for (int counter = 0; counter < rhombusSize; counter++)
        {
            PrintRow(rhombusSize,counter);
        }
        for (int counter = rhombusSize; counter > 0; counter--)
        {
            PrintRow(rhombusSize,counter);
        }
    }
}
