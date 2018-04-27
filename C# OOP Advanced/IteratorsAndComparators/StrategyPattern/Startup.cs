using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        NameComparator nameComparator = new NameComparator();
        AgeComparator ageComparator = new AgeComparator();

        SortedSet<Person> personsByName = new SortedSet<Person>(nameComparator);
        SortedSet<Person> personsByAge = new SortedSet<Person>(ageComparator);

        int n = int.Parse(Console.ReadLine());

        for (int counter = 0; counter < n; counter++)
        {
            List<string> args = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string name = args[0];
            int age = int.Parse(args[1]);

            Person person = new Person(name, age);

            personsByName.Add(person);
            personsByAge.Add(person);
        }

        Console.WriteLine(string.Join(Environment.NewLine, personsByName));
        Console.WriteLine(string.Join(Environment.NewLine, personsByAge));
    }
}
