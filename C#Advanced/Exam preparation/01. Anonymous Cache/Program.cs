using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Anonymous_Cache
{
    public class Startup
    {
        public static void Main()
        {
            var data = new Dictionary<string, Dictionary<string, long>>();
            var cache = new Dictionary<string, List<string>>();

            string input;

            while ((input = Console.ReadLine()) != "thetinggoesskrra")
            {
                List<string> arguments = input
                    .Split(new char[] { ' ', '-', '>', '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string dataSet = "";
                string dataKey = "";
                long dataSize;
                
                if (arguments.Count == 1)
                {
                    dataSet = arguments[0];
                    data[dataSet] = new Dictionary<string, long>();

                }
                if (cache.ContainsKey(dataSet))
                {
                    foreach (var args in cache[dataSet])
                    {
                        List<string> tokens = args.Split(' ').ToList();

                        string datakey = tokens[0];
                        long datasize = long.Parse(tokens[1]);

                        data[dataSet][datakey] = datasize;
                    }
                    cache.Remove(dataSet);
                }
                if(arguments.Count > 1)
                {
                    dataKey = arguments[0];
                    dataSize = long.Parse(arguments[1]);
                    dataSet = arguments[2];

                    if (data.ContainsKey(dataSet))
                    {
                        data[dataSet][dataKey] = dataSize;
                    }
                    if (!cache.ContainsKey(dataSet))
                    {
                        cache[dataSet] = new List<string>();
                    }
                    if (cache.ContainsKey(dataSet))
                    {
                        cache[dataSet].Add($"{dataKey} {dataSize}");
                    }
                    
                }
               
            }

            long maxSum = 0;
            string key = "";

            foreach (var dataset in data)
            {
                Dictionary<string, long> current = dataset.Value;
                List<long> currentNums = current.Values.ToList();

                if (currentNums.Sum() > maxSum)
                {
                    maxSum = currentNums.Sum();
                    key = dataset.Key;
                }
            }

            Console.WriteLine($"Data Set: {key}, Total Size: {maxSum}");

            foreach (var arg in data[key])
            {
                Console.WriteLine($@"$.{arg.Key}");
            }
        }
    }
}
