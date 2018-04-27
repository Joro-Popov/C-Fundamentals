using System;
using System.Collections.Generic;
using System.Linq;

public class PriceCalculator
{
    public static decimal TotalPrice { get; set; }
    public static int Nights { get; set; }
    public static SeasonsEnum Season { get; set; }
    public static DiscountsEnum Discount { get; set; }

    public PriceCalculator(string command)
    {
        var splitCommand = command.Split();
        TotalPrice = decimal.Parse(splitCommand[0]);
        Nights = int.Parse(splitCommand[1]);
        Season = Enum.Parse<SeasonsEnum>(splitCommand[2]);
        Discount = DiscountsEnum.None;
        if (splitCommand.Length > 3)
        {
            Discount = Enum.Parse<DiscountsEnum>(splitCommand[3]);
        }
    }
    public static string CalculatePrice(string command)
    {
        var tempTotal = TotalPrice * Nights * (int)Season;
        var discountPercentage = ((decimal)100 - (int)Discount) / 100;
        var total = tempTotal * discountPercentage;
        return total.ToString("F2");
    }
}
