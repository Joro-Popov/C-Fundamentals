using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _03.Word_Count
{
    public class StratUp
    {
        public static void Main()
        {
            var occurences = new Dictionary<string, int>();
            List<string> words = new List<string>();
            
            using (var reader = new StreamReader("words.txt"))
            {
                string word = reader.ReadLine().ToLower();

                while (word != null)
                {
                    occurences[word] = 0;
                    word = reader.ReadLine();
                }
                
            }

            using (var reader = new StreamReader("text.txt"))
            {
                words = reader.ReadToEnd()
                    .Split(new string[] { " ", ",", "?", "!", ".", "-", Environment.NewLine }
                    , StringSplitOptions.RemoveEmptyEntries)
                    .Select(w => w.ToLower())
                    .ToList();
            }

            foreach (var word in words)
            {
                if (occurences.ContainsKey(word))
                {
                    occurences[word]++;
                }
            }

            occurences = occurences
                .OrderByDescending(w => w.Value)
                .ToDictionary(w => w.Key, w => w.Value);

            using (var writer = new StreamWriter("result.txt"))
            {
                foreach (var word in occurences)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
