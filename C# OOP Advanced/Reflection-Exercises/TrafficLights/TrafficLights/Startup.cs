﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficLights
{
    public class Startup
    {
        public static void Main()
        {
            var trafficLights = Console.ReadLine().Trim().Split()
                 .Select(x => new TrafficLight(x))
                 .ToList();

            var n = int.Parse(Console.ReadLine().Trim());

            for (int i = 0; i < n; i++)
            {
                trafficLights.ForEach(t => t.ToggleSignal());
                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }
    }
}
