using System;

public class Startup
{
    private static void Main()
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());

        try
        {
            Child child = new Child(name, age);
            Console.WriteLine(child);
        }
        catch (Exception ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}