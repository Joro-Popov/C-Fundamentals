using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        SortedSet<Person> personSet = new SortedSet<Person>();
        HashSet<Person> personHash = new HashSet<Person>();

        int n = int.Parse(Console.ReadLine());

        for (int counter = 0; counter < n; counter++)
        {
            List<string> args = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string name = args[0];
            int age = int.Parse(args[1]);

            Person person = new Person(name, age);

            personSet.Add(person);
            personHash.Add(person);
        }

        Console.WriteLine(personSet.Count());
        Console.WriteLine(personHash.Count());
    }
}
