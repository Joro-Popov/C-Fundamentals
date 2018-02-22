using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Text_Transformer
{
    public class Startup
    {
        public static string ExtractFullText()
        {
            string input;
            StringBuilder text = new StringBuilder();

            while ((input = Console.ReadLine()) != "burp")
            {
                text.Append(input);
            }
            string finalText = Regex.Replace(text.ToString(), @"\s+", " ");

            return finalText;
        }
        public static int GetSymbolWeight(string symbol)
        {
            int weight = 0;

            switch (symbol)
            {
                case "$": weight = 1; break;
                case "%": weight = 2; break;
                case "&": weight = 3; break;
                case "'": weight = 4; break;
            }
            return weight;
        }
        private static string GetResult(MatchCollection matches)
        {
            StringBuilder result = new StringBuilder();

            foreach (Match match in matches)
            {
                string symbol = match.Groups["symbol"].Value;
                string data = match.Groups["data"].Value;
                int weight = GetSymbolWeight(symbol);

                for (int index = 0; index < data.Length; index++)
                {
                    if (index % 2 == 0)
                    {
                        char toAdd = (char)(data[index] + weight);
                        result.Append(toAdd);
                    }
                    else
                    {
                        char toAdd = (char)(data[index] - weight);
                        result.Append(toAdd);
                    }
                }
                result.Append(" ");
            }
            return result.ToString();
        }
        public static void Main()
        {
            string text = ExtractFullText();
            Regex dataPattern = new Regex(@"(?<symbol>[$%&'])(?<data>[^$%&']+)\1");
            MatchCollection matches = dataPattern.Matches(text);
            GetResult(matches);
            string result = GetResult(matches);
            Console.WriteLine(result);
        }

       
    }
}
