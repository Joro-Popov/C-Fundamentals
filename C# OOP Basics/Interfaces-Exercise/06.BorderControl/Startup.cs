using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Startup
{
    private static void Main()
    {
        ControlSystem system = new ControlSystem();

        int num = int.Parse(Console.ReadLine());

        for (int index = 0; index < num; index++)
        {
            List<string> info = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            if (info.Count == 3)
            {
                Person rebel = new Rebel(info[0], int.Parse(info[1]), info[2]);
                system.Buyers[info[0]] = rebel;
                
            }
            else
            {
                Person citizen = new Citizen(info[0], int.Parse(info[1]), info[2]);
                system.Buyers[info[0]] = citizen;
            }
        }
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string name = command;

            if (NameIsValid(name) && system.Buyers.ContainsKey(name))
            {
                system.Buyers[name].BuyFood();
            }
        }
        int totalAmount = system.Buyers.Sum(b => b.Value.Food);
        Console.WriteLine(totalAmount);
    }
    private static bool NameIsValid(string name)
    {
        Regex validatePattern = new Regex(@"[A-Z][a-z]+");
        if (validatePattern.IsMatch(name))
        {
            return true;
        }
        return false;
    }
    
}