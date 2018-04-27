using System;

public class Startup
{
    public static void Main()
    {
        string figureType = Console.ReadLine();
        int sideA = 0;
        int sideB = 0;

        if (figureType.Equals("Square"))
        {
            sideA = int.Parse(Console.ReadLine());
            sideB = sideA;
        }
        else
        {
            sideA = int.Parse(Console.ReadLine());
            sideB = int.Parse(Console.ReadLine());
        }
        Figure figure = new Figure(sideA, sideB);
        figure.Draw();
    }
}
