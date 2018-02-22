using System;
using System.Linq;
using System.Collections.Generic;

namespace _12._Inferno_III
{
    public class Startup
    {
        public static void Main()
        {
            List<int> gems = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<string> filters = new List<string>();

            string commandInput;

            while ((commandInput = Console.ReadLine()) != "Forge")
            {
                List<string> tokens = commandInput.Split(';').ToList();
                
                string command = tokens[0];
                string filterType = tokens[1];
                int filterparam = int.Parse(tokens[2]);

                string filter = $"{filterType};{filterparam}";

                switch (command)
                {
                    case "Exclude": filters.Add(filter); break;
                    default: filters.RemoveAt(filters.Count - 1); break;
                }
            }

            foreach (var filter in filters)
            {
                List<string> argumets = filter.Split(';').ToList();

                string type = argumets[0];
                int param = int.Parse(argumets[1]);

                switch (type)
                {
                    case "Sum Left": gems = gems.Where(g =>
                    {
                        int leftGem;

                        if (gems.IndexOf(g) == 0) leftGem = 0;
                        else leftGem = gems[gems.IndexOf(g) - 1];
                        return !(g + leftGem == param);

                    }).ToList();break;
                    case "Sum Right": gems = gems.Where(g =>
                    {
                        int rightGem;

                        if (gems.IndexOf(g) == gems.Count - 1) rightGem = 0;
                        else rightGem = gems[gems.IndexOf(g) + 1];
                        return !(g + rightGem == param);
                    }).ToList();break;
                    case "Sum Left Right": gems = gems.Where(g =>
                    {
                        int leftGem;
                        int rightGem;

                        if (gems.IndexOf(g) == 0) leftGem = 0;
                        else leftGem = gems[gems.IndexOf(g) - 1];

                        if (gems.IndexOf(g) == gems.Count - 1) rightGem = 0;
                        else rightGem = gems[gems.IndexOf(g) + 1];
                        
                        return !(g + leftGem + rightGem == param);
                    }).ToList();break;
                }
                
            }
            Console.WriteLine(string.Join(" ", gems));
        }
    }
}
