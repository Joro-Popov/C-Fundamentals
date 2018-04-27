using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main()
    {
        List<Person> parents = new List<Person>();
        string[] input = Console.ReadLine().Split();
        Person mainPerson = new Person();
        FillPersonData(input, mainPerson);

        string info;
        while ((info = Console.ReadLine()) != "End")
        {
            if (info.Contains('-'))
            {
                string[] tokens = info.Split(" - ");
                string[] parentInfo = tokens[0].Split();
                string[] childInfo = tokens[1].Split();
                Person parent = new Person();
                Person child = new Person();
                FillPersonData(parentInfo, parent);
                FillPersonData(childInfo, child);
                parent.Childrens.Add(child);
                if (parents.Contains(parent))
                {
                    for (int count = 0; count < parents.Count; count++)
                    {
                        if (parents[count].FirstName.Equals(parent.FirstName) || parents[count].Birthday.Equals(parent.Birthday))
                        {
                            parents[count].Childrens.Add(child);
                        }
                    }
                }
                else
                {
                    parents.Add(parent);
                }
            }
            else
            {
                string[] tokens = info.Split();
                Person person = new Person();
                person.FirstName = tokens[0];
                person.LastName = tokens[1];
                person.Birthday = tokens[2];

                if (parents.Contains(person))
                {
                    for (int count = 0; count < parents.Count; count++)
                    {
                        if (parents[count].Equals(person))
                        {
                            parents[count] = person;
                            break;
                        }
                    }
                }
            }
        }
    }
    
    public static void FillPersonData(string[] input, Person mainPerson)
    {
        if (input.Length == 1)
        {
            mainPerson.Birthday = input[0];
        }
        else
        {
            mainPerson.FirstName = input[0];
            mainPerson.LastName = input[1];
        }
    }
}
