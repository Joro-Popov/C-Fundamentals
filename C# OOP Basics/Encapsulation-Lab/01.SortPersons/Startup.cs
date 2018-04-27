using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main()
    {
        var lines = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();
        for (int count = 0; count < lines; count++)
        {
            string[] Info = Console.ReadLine().Split();
            Person currentPerson = new Person(Info[0], Info[1], int.Parse(Info[2]));
            persons.Add(currentPerson);
        }
        persons.OrderBy(p => p.FirstName)
            .ThenBy(p => p.Age)
            .ToList()
            .ForEach(p => Console.WriteLine(p));
    }
}
