using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04._Events
{
    public class Time
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }

        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }
    }
    public class Startup
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            var events = new Dictionary<string, Dictionary<string, List<Time>>>();

            for (int index = 0; index < count; index++)
            {
                string input = Console.ReadLine();
                Regex pattern = new Regex(@"^#(?<name>[A-z]+):\s*@(?<location>[A-z]+)\s*(?<hours>[0-1][0-9]|2[0-3]):(?<minutes>[0-5][0-9])$");
                Match match = pattern.Match(input);

                if (match.Success)
                {
                    string person = match.Groups["name"].Value;
                    string location = match.Groups["location"].Value;
                    int hours = int.Parse(match.Groups["hours"].Value);
                    int minutes = int.Parse(match.Groups["minutes"].Value);
                    Time time = new Time(hours, minutes);

                    if (!events.ContainsKey(location))
                    {
                        events[location] = new Dictionary<string, List<Time>>();
                    }
                    if (!events[location].ContainsKey(person))
                    {
                        events[location][person] = new List<Time>();
                    }
                    events[location][person].Add(time);
                }
            }
            List<string> locations = Console.ReadLine()
                .Split(',')
                .OrderBy(l => l)
                .ToList();

            foreach (var loc in locations.OrderBy(l => l))
            {
                if (!events.ContainsKey(loc))
                {
                    continue;
                }
                Console.WriteLine($"{loc}:");

                Dictionary<string, List<Time>> currentPersons = events[loc];

                currentPersons = currentPersons
                    .OrderBy(w => w.Key)
                    .ToDictionary(k => k.Key, v => v.Value);

                int index = 1;

                foreach (var person in currentPersons)
                {
                    string name = person.Key;
                    List<Time> times = person.Value;

                    times = times
                        .OrderBy(h => h.Hours)
                        .ThenBy(h => h.Minutes)
                        .ToList();

                    Console.Write($"{index}. {name} -> ");

                    for (int i = 0; i < times.Count; i++)
                    {
                        if (i == times.Count - 1)
                        {
                            Console.Write($"{times[i].Hours}:{times[i].Minutes:d2}");
                        }
                        else
                        {
                            Console.Write($"{times[i].Hours}:{times[i].Minutes:d2}, ");
                        }
                    }
                    Console.WriteLine();
                    index++;
                }
            }
        }
    }
}
