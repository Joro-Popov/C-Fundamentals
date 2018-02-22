using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _03._Rage_Quit
{
    public class Program
    {
        public static void Main()
        {
            StringBuilder result = new StringBuilder();
            string input = Console.ReadLine();
            Regex pattern = new Regex(@"((?<text>[^\d]+)(?<number>[0-9]+))");
            MatchCollection matches = pattern.Matches(input);
            HashSet<char> repeats = new HashSet<char>();
            
            foreach (Match match in matches)
            {
                string text = match.Groups["text"].Value.ToUpper();
                int number = int.Parse(match.Groups["number"].Value);

                foreach (var c in text)
                {
                    repeats.Add(c);
                }
                for (int i = 0; i < number; i++)
                {
                    result.Append(text);
                }
            }

            Console.WriteLine($"Unique symbols used: {repeats.Count}");
            Console.WriteLine($"{result.ToString()}");
        }
    }
}
