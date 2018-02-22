using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._Predicate_Party_
{
    public static class MyExtenssions
    {
        public static List<string> RemoveByCriteria(this List<string> guests,Func<string,bool> checker)
        {
            List<string> result = new List<string>();

            foreach (var guest in guests)
            {
                if (!checker(guest))
                {
                    result.Add(guest);
                }
            }
            return result;
        }
        public static List<string> DoubleByCriteria(this List<string> guests, Func<string, bool> checker)
        {
            List<string> result = new List<string>();

            foreach (var guest in guests)
            {
                if (checker(guest))
                {
                    result.Add(guest);
                    
                }
                result.Add(guest);
            }
            return result;
        }
    }

    public class Startup
    {
        public static void Main()
        {
            List<string> guests = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                List<string> arguments = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string action = arguments[0];
                string criteria = arguments[1];
                string argument = arguments[2];

                if (action == "Remove")
                {
                    switch (criteria)
                    {
                        case "StartsWith": guests = guests.RemoveByCriteria(g => g.StartsWith(argument)); break;
                        case "EndsWith": guests = guests.RemoveByCriteria(g => g.EndsWith(argument)); break;
                        case "Length": guests = guests.RemoveByCriteria(g => g.Length == int.Parse(argument)); break;
                    }
                }
                else
                {
                    switch (criteria)
                    {
                        case "StartsWith": guests = guests.DoubleByCriteria(g => g.StartsWith(argument)); break;
                        case "EndsWith": guests = guests.DoubleByCriteria(g => g.EndsWith(argument)); break;
                        case "Length": guests = guests.DoubleByCriteria(g => g.Length == int.Parse(argument)); break;
                    }
                }

                command = Console.ReadLine();
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
