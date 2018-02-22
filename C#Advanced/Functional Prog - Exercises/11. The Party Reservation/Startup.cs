using System;
using System.Linq;
using System.Collections.Generic;

namespace _11._The_Party_Reservation
{
    public class Startup
    {
        public static void Main()
        {
            List<string> names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> filters = new List<string>();

            string commandInput;

            while ((commandInput = Console.ReadLine()) != "Print")
            {
                List<string> tokens = commandInput
                    .Split(';')
                    .ToList();

                string command = tokens[0];
                string filterType = tokens[1];
                string filterParam = tokens[2];

                string filter = $"{filterType};{filterParam}";

                switch (command)
                {
                    case "Add filter": filters.Add(filter); break;
                    default: filters = filters.Where(f => f != filter).ToList(); break;
                }
                
            }

            foreach (var filter in filters)
            {
                List<string> tokens = filter.Split(';').ToList();
                string type = tokens[0];
                string param = tokens[1];

                switch (type)
                {
                    case "Starts with": names = names.Where(n => !n.StartsWith(param)).ToList(); break;
                    case "Ends with": names = names.Where(n => !n.EndsWith(param)).ToList(); break;
                    case "Length": names = names.Where(n => !(n.Length == int.Parse(param))).ToList(); break;
                    case "Contains": names = names.Where(n => !n.Contains(param)).ToList(); break;
                }
            }

            Console.WriteLine(string.Join(" ",names));
        }
    }
}
