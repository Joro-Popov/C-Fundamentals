using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        List<Person> employees = new List<Person>();
        for (int count = 0; count < lines; count++)
        {
            List<string> info = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Person person = new Person(info[0],
                                       info[1],
                                       int.Parse(info[2]),
                                       decimal.Parse(info[3]));
            employees.Add(person);
        }
        decimal percentage = decimal.Parse(Console.ReadLine());
        employees.ForEach(p => p.IncreaseSalary(percentage));
        employees.ForEach(p => Console.WriteLine(p));
    }
}
