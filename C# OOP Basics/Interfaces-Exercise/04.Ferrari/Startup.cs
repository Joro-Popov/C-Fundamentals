using System;

public class Startup
{
    private static void Main()
    {
        ICar ferrari = new Ferrari(Console.ReadLine());
        Console.WriteLine(ferrari);
    }
}