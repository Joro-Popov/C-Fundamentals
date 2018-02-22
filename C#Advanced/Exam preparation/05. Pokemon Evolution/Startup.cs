using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Pokemon_Evolution
{
    public class Evolution
    {
        public long Index { get; set; }
        public string Type { get; set; }

        public Evolution(string type, long index)
        {
            Type = type;
            Index = index;
        }
    }
    public class Startup
    {
        public static void Main()
        {
            string input;
            var evolutions = new Dictionary<string, List<Evolution>>();

            while ((input = Console.ReadLine()) != "wubbalubbadubdub")
            {
                List<string> arguments = input
                    .Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (arguments.Count == 1)
                {
                    string pokemonName = arguments[0];

                    if (evolutions.ContainsKey(pokemonName))
                    {
                        Console.WriteLine($"# {pokemonName}");

                        foreach (var evo in evolutions[pokemonName])
                        {
                            Console.WriteLine($"{evo.Type} <-> {evo.Index}");
                        }
                    }
                }
                else
                {
                    string pokemonName = arguments[0];
                    string evolutionType = arguments[1];
                    long evolutionIndex = long.Parse(arguments[2]);

                    Evolution evolution = new Evolution(evolutionType, evolutionIndex);

                    if (!evolutions.ContainsKey(pokemonName))
                    {
                        evolutions[pokemonName] = new List<Evolution>();
                    }
                    evolutions[pokemonName].Add(evolution);
                }
            }

            foreach (var evol in evolutions)
            {
                string pokemonName = evol.Key;
                List<Evolution> evos = evol.Value;

                Console.WriteLine($"# {pokemonName}");

                foreach (var ev in evos.OrderByDescending(w => w.Index))
                {
                    Console.WriteLine($"{ev.Type} <-> {ev.Index}");
                }
            }
        }
    }
}
