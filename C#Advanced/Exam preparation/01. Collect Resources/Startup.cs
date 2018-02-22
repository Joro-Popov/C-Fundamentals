using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Collect_Resources
{
    public class Startup
    {
        public static void Main()
        {
            List<string> elements = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int num = int.Parse(Console.ReadLine());
            long maxValue = 0;

            for (int index = 0; index < num; index++)
            {
                List<int> arguments = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();

                int startIndex = arguments[0];
                int stepIndex = arguments[1];
                long totalValue = 0;

                while (true)
                {
                    int pos = startIndex % (elements.Count);
                    
                    string currentElement = elements[pos];

                    List<string> tokens = currentElement.Split('_').ToList();
                    string type = tokens[0];
                    
                    if (type == "stone" || type ==  "gold" ||
                        type == "wood" || type == "food")
                    {
                        if (tokens.Count == 1) totalValue += 1;
                        else totalValue += long.Parse(tokens[1]);
                    }
                    startIndex += stepIndex;

                    if (startIndex % (elements.Count) == arguments[0])
                    {
                        break;
                    }

                }
                if (totalValue > maxValue)
                {
                    maxValue = totalValue;
                }
            }
            Console.WriteLine(maxValue);
        }
    }
}
