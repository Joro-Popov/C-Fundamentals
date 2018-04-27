using System;

public class Startup
{
    private static void Main()
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());
        try
        {
            Box box = new Box(length, width, height);

            Console.WriteLine($"Surface Area - {box.GetSurfaceArea():f2}\r\n" +
                              $"Lateral Surface Area - {box.GetLateralSurfaceArea():F2}\r\n" +
                              $"Volume - {box.GetVolume():f2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}