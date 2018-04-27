using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main()
    {
        string commad;
        while ((commad = Console.ReadLine()) != "End")
        {
            List<string> info = commad
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Citizen citizen = new Citizen(info[0], info[1], int.Parse(info[2]));
            Console.WriteLine((citizen as IPerson).GetName());
            Console.WriteLine((citizen as IResident).GetName());
        }
    }
}
