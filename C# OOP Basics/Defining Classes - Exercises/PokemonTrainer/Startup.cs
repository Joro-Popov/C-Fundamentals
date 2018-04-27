using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Startup
    {
        public static void CheckForElement(Dictionary<string,Trainer>trainers,string element)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Value.Pokemons.Any(p => p.Element.Equals(element)))
                {
                    trainer.Value.BadgesCount++;
                }
                else
                {
                    for (int index = 0; index < trainer.Value.Pokemons.Count; index++)
                    {
                        Pokemon current = trainer.Value.Pokemons[index];
                        current.Health -= 10;

                        if (current.Health <= 0)
                        {
                            trainer.Value.Pokemons.RemoveAt(index);
                            index--;
                        }
                    }
                }
            }
        }
        public static void Main()
        {
            var trainers = new Dictionary<string, Trainer>();
            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                List<string> pokemonInfo = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string trainerName = pokemonInfo[0];
                string pokemonName = pokemonInfo[1];
                string pokemonElement = pokemonInfo[2];
                long pokemonHealth = long.Parse(pokemonInfo[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer trainer = new Trainer(trainerName);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = trainer;
                }
                trainers[trainerName].Pokemons.Add(pokemon);
            }
            string element;
            while ((element = Console.ReadLine()) != "End")
            {
                switch (element)
                {
                    case "Fire": CheckForElement(trainers, element); break;
                    case "Water": CheckForElement(trainers, element); break;
                    case "Electricity": CheckForElement(trainers, element); break;
                }
            }
            foreach (var trainer in trainers.OrderByDescending(t => t.Value.BadgesCount))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.BadgesCount} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
