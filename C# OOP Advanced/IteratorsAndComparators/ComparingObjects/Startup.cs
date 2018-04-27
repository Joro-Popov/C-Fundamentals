using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main()
    {
        string command;

        int equalToHim = 0;
        int notEqualToHim = 0;
        int totalPersons = 0;

        List<Person> persons = new List<Person>();

        while ((command = Console.ReadLine()) != "END")
        {
            List<string> args = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string name = args[0];
            int age = int.Parse(args[1]);
            string town = args[2];

            Person person = new Person(name, age, town);

            persons.Add(person);
        }

        int currentPersonIndex = int.Parse(Console.ReadLine());

        Person currentPerson = persons[currentPersonIndex - 1];

        foreach (var person in persons)
        {
            if (currentPerson.CompareTo(person) == 0)
            {
                equalToHim++;
            }
            else
            {
                notEqualToHim++;
            }

            totalPersons++;
        }

        if (equalToHim == 1)
        {
            Console.WriteLine($"No matches");
        }
        else
        {
            Console.WriteLine($"{equalToHim} {notEqualToHim} {totalPersons}");
        }
    }
}
