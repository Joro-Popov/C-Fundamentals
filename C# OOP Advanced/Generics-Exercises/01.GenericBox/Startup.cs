using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<string> elements = new List<string>();

        for (int counter = 0; counter < n; counter++)
        {
            string element = Console.ReadLine();
            elements.Add(element);
        }

        string toCompare = Console.ReadLine();

        int result = Comparator.Compare(elements, toCompare);

        Console.WriteLine(result);
    }
}
