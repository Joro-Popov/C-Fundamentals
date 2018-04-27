using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();
        for (int index = 0; index < count; index++)
        {
            List<string> personInfo = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Person person = new Person(personInfo[0],
                                       personInfo[1],
                                       int.Parse(personInfo[2]),
                                       decimal.Parse(personInfo[3]));
            persons.Add(person);
        }
        Team team = new Team("SoftUni");
        foreach (var person in persons)
        {
            team.AddPlayer(person);
        }
        Console.WriteLine(team);
    }
}
