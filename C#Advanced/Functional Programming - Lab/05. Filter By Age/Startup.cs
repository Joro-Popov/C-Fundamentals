using System;
using System.Linq;
using System.Collections.Generic;


namespace _05._Filter_By_Age
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public class Startup
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();
            CreatePersons(num,persons);

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            var filter = CreateFilter(condition,age);
            var printer = CreatePrinter(format);

            foreach (var person in persons)
            {
                if (filter(person))
                {
                    printer(person);
                }
            }

        }
        public static Func<Person,bool> CreateFilter(string condition, int age)
        {
            switch (condition)
            {
                case "younger": return x => x.Age < age;
                case "older": return x => x.Age >= age;
                default: return null;
            }
        }
        public static Action<Person> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name": return person => Console.WriteLine($"{person.Name}");
                case "age": return person => Console.WriteLine($"{person.Age}");
                case "name age": return person => Console.WriteLine($"{person.Name} - {person.Age}");
                default: return null;
            }
        }
        public static void CreatePersons(int num,List<Person> persons)
        {
            for (int i = 0; i < num; i++)
            {
                List<string> arguments = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string name = arguments[0];
                int age = int.Parse(arguments[1]);

                Person currentPerson = new Person(name, age);
                persons.Add(currentPerson);
            }
        }
    }
}
