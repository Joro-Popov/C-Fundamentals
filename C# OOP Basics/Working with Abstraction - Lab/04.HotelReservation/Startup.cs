using System;

public class Startup
{
    public static void Main()
    {
        string command = Console.ReadLine();
        var priceCalculator = new PriceCalculator(command);
        
    }
}
