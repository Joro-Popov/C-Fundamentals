using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    private static void Main(string[] args)
    {
        List<string> tokens = GetTokens();

        MyTuple<string, string, string> threeupleOne = new MyTuple<string, string, string>((tokens[0] + " " + tokens[1]), tokens[2], tokens[3]);

        tokens = GetTokens();

        MyTuple<string, int, bool> threeupleTwo = new MyTuple<string, int, bool>(tokens[0], int.Parse(tokens[1]), tokens[2] == "drunk" ? true : false);

        tokens = GetTokens();

        MyTuple<string, double, string> threeupleThree = new MyTuple<string, double, string>(tokens[0], double.Parse(tokens[1]), tokens[2]);

        Console.WriteLine(threeupleOne);
        Console.WriteLine(threeupleTwo);
        Console.WriteLine(threeupleThree);
    }

    private static List<string> GetTokens()
    {
        return Console.ReadLine().Split().ToList();
    }
}

