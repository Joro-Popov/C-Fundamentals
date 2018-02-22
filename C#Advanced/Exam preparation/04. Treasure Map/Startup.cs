using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04._Treasure_Map
{
    public class Startup
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            List<string> Adresses = new List<string>();

            for (int count = 0; count < num; count++)
            {
                string input = Console.ReadLine();
                Regex pattern = new Regex(@"(#([^#!])*(?<=[^\w\d])[A-z]{4}(?=[^\w\d])([^#!]*)[0-9]{3}-[0-9]{4,6}[^#!]*!)|(!([^#!])*(?<=[^\w\d])[A-z]{4}(?=[^\w\d])([^#!]*)[0-9]{3}-[0-9]{4,6}[^#!]*#)");
                MatchCollection matches = pattern.Matches(input);

                string extracted = "";

                if (matches.Count > 1 && matches.Count % 2 == 0)
                {
                    extracted = matches[matches.Count / 2].Value;
                    
                }
                else
                {
                    extracted = matches[0].Value;
                }
                Regex instrPattern = new Regex(@"(?<![^A-z]{4})(?<street>\b[A-z]{4}\b).*(?<num>[0-9]{3})-(?<pass>[0-9]{4,6})");
                Match match = instrPattern.Match(extracted);
                string street = match.Groups["street"].Value;
                string number = match.Groups["num"].Value;
                string pass = match.Groups["pass"].Value;

                Console.WriteLine($"Go to str. {street} {number}. Secret pass: {pass}.");
                
            }
        }
    }
}
