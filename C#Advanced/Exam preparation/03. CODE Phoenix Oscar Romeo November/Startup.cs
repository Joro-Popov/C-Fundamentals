using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._CODE_Phoenix_Oscar_Romeo_November
{
    public class Startup
    {
        public static void FilterSqads(Dictionary<string, List<string>> sqads)
        {
            List<string> keys = sqads.Keys.ToList();

            foreach (var key in keys)
            {
                List<string> values = sqads[key];

                for (int i = 0; i < values.Count; i++)
                {
                    string currentMate = values[i];

                    if (keys.Contains(currentMate))
                    {
                        if (sqads[currentMate].Contains(key))
                        {
                            sqads[currentMate].Remove(key);
                            sqads[key].Remove(currentMate);
                        }
                    }
                }
            }
        }
        public static void Main()
        {
            string input;
            var sqads = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "Blaze it!")
            {
                List<string> creatureInfo = input
                    .Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string creature = creatureInfo[0];
                string sqadMate = creatureInfo[1];

                if (sqads.ContainsKey(creature))
                {
                    if (!sqads[creature].Contains(sqadMate) && creature != sqadMate)
                    {
                        sqads[creature].Add(sqadMate);
                    }
                }
                else
                {
                    sqads[creature] = new List<string>();
                    sqads[creature].Add(sqadMate);
                }
            }

            FilterSqads(sqads);

            foreach (var sqad in sqads.OrderByDescending(w => w.Value.Count))
            {
                Console.WriteLine($"{sqad.Key} : {sqad.Value.Count}");
            }
        }
        
    }
}
