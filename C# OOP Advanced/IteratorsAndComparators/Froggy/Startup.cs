using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main()
    {
        List<int> stones = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        StonesCollection<int> collection = new StonesCollection<int>(stones);

        Console.WriteLine(string.Join(", ",collection));
    }
}
