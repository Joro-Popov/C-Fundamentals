using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    private static void Main()
    {
        List<string> phoneNumbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        List<string> urls = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        Smartphone phone = new Smartphone(phoneNumbers, urls);
        phone.Call();
        phone.Browse();
    }
}