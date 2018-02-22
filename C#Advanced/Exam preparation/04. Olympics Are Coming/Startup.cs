using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04._Olympics_Are_Coming
{
    public class Startup
    {
        public static void Main()
        {
            string input;
            var Countries = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "report")
            {
                input = Regex.Replace(input, @"\s+", " ");

                List<string> arguments = input
                    .Split(new string[] { " | "," |","| ","|" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string participantName = arguments[0];
                string countryName = arguments[1];

                if (!Countries.ContainsKey(countryName))
                {
                    Countries[countryName] = new Dictionary<string, int>();
                }
                if (!Countries[countryName].ContainsKey(participantName))
                {
                    Countries[countryName][participantName] = 0;
                }
                Countries[countryName][participantName]++;

                
            }
            Countries = Countries
                    .OrderByDescending(c => c.Value.Values.Sum())
                    .ToDictionary(k => k.Key, v => v.Value);

            foreach (var country in Countries)
            {
                string currentCountry = country.Key;
                Dictionary<string, int> participants = country.Value;

                Console.WriteLine($"{currentCountry} ({participants.Keys.Count} participants): {participants.Values.Sum()} wins");
            }
        }
    }
}
