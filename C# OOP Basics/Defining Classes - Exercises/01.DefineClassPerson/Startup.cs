using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        var departments = new Dictionary<string, List<Employee>>();

        for (int index = 0; index < count; index++)
        {
            List<string> tokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Employee employee = new Employee(tokens);
            if (!departments.ContainsKey(tokens[3]))
            {
                departments[tokens[3]] = new List<Employee>();
            }
            departments[tokens[3]].Add(employee);
        }

        departments = departments
            .OrderByDescending(w => w.Value.Sum(e => e.Salary) / w.Value.Count)
            .ToDictionary(k => k.Key, v => v.Value);

        foreach (var dep in departments)
        {
            string department = dep.Key;
            List<Employee> employees = dep.Value;

            Console.WriteLine($"Highest Average Salary: {department}");

            foreach (var employee in employees.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine(employee);
            }
            return;
        }
    }
}
