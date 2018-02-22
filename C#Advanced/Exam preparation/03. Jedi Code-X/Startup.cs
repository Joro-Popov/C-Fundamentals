using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Jedi_Code_X
{
    public class Startup
    {
        public static void Main()
        {
            List<string> names = new List<string>();
            List<string> messages = new List<string>();
            List<string> encodedTexts = new List<string>();

            int n = int.Parse(Console.ReadLine());
            
            for (int count = 0; count < n; count++)
            {
                string encodedText = Console.ReadLine();
                encodedTexts.Add(encodedText);
            }

            string prefixName = Console.ReadLine();
            string prefixMessage = Console.ReadLine();
            Queue<int> indexes = new Queue<int> (Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToList());

            int namelength = prefixName.Length; 
            int messageLength = prefixMessage.Length;

            Regex namePattern = new Regex($@"{prefixName}(?<name>[A-z]{{{namelength}}})");
            Regex messagePattern = new Regex($@"{prefixMessage}(?<message>[A-z0-9]{{{messageLength}}})");

            foreach (var text in encodedTexts)
            {
                MatchCollection matchedNames = namePattern.Matches(text);
                MatchCollection matchedMessages = messagePattern.Matches(text);

                names.AddRange(matchedNames
                    .Cast<Match>()
                    .Select(w => w.Groups["name"].Value)
                    .ToList());

                messages.AddRange(matchedMessages
                    .Cast<Match>()
                    .Select(w => w.Groups["message"].Value)
                    .ToList());
            }

            List<string> jedis = new List<string>();
            
            int counter = Math.Min(names.Count, indexes.Count);

            for (int i = 0; i < counter; i++)
            {
                string jedi = names[i];

                if (indexes.Count > 0)
                {
                    int index = indexes.Dequeue() - 1;

                    if (index< messages.Count)
                    {
                        jedis.Add($"{jedi} - {messages[index]}");
                    }
                    else
                    {
                        while (indexes.Count > 0)
                        {
                            int tempIndex = indexes.Dequeue() - 1;

                            if (tempIndex < messages.Count)
                            {
                                jedis.Add($"{jedi} - {messages[index]}");
                                break;
                            }
                        }
                    }
                }
                else
                {
                    List<string> tokens = jedis[1]
                        .Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    string message = tokens[1];

                    jedis.Add($"{jedi} - {message}");
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine,jedis));
        }
    }
}
