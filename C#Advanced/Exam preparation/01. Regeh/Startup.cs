using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.Phonebook
{
    public class Phonebook
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string result = "";

            Regex pattern = new Regex(@"\[[^\s\[]+<(?<num1>[0-9]+)REGEH(?<num2>[0-9]+)>[^\s\]]+\]");
            MatchCollection matches = pattern.Matches(text);

            if (matches.Count > 0)
            {
                List<int> indexes = new List<int>();
                int index = 0;

                foreach (Match match in matches)
                {
                    indexes.Add(int.Parse(match.Groups["num1"].Value));
                    indexes.Add(int.Parse(match.Groups["num2"].Value));
                }

                for (int i = 0; i < indexes.Count; i++)
                {
                    index += indexes[i];

                    if (index > text.Length - 1)
                    {
                        do
                        {
                            index -= text.Length - 1;
                        } while (index > text.Length - 1);
                    }
                    result += text[index];
                }
            }

            Console.WriteLine(result);
        }
    }
}
