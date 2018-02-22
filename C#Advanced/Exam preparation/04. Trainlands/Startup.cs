using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_04
{
    class Wagon
    {
        public int Power { get; set; }
        public string Name { get; set; }

        public Wagon(string name, int power)
        {
            Power = power;
            Name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Wagon>> AllTrains =
            new Dictionary<string, List<Wagon>>();

            string Input = Console.ReadLine();

            while (Input != "It's Training Men!")
            {
                if (Input.Contains("->") && Input.Contains(":"))
                {
                    List<string> Tokens = Input
                        .Split(new char[] { ' ', '-', '>', ':', '=' },
                         StringSplitOptions
                        .RemoveEmptyEntries)
                        .ToList();

                    string TrainName = Tokens[0];
                    string WagonName = Tokens[1];
                    int WagonPower = int.Parse(Tokens[2]);

                    Wagon CurrentWagon = new Wagon(WagonName, WagonPower);

                    if (!AllTrains.ContainsKey(TrainName))
                    {
                        AllTrains[TrainName] = new List<Wagon>();

                    }

                    AllTrains[TrainName].Add(CurrentWagon);

                }
                else
                {
                    if (Input.Contains("->"))
                    {
                        List<string> Tokens = Input
                        .Split(new string[] { " -> " },
                         StringSplitOptions
                        .RemoveEmptyEntries)
                        .ToList();

                        string FirstName = Tokens[0];
                        string OtherName = Tokens[1];

                        if (!AllTrains.ContainsKey(FirstName))
                        {
                            AllTrains[FirstName] = new List<Wagon>();

                        }

                        List<Wagon> TokenWagons = AllTrains[OtherName];
                        AllTrains[FirstName].AddRange(TokenWagons);
                        AllTrains.Remove(OtherName);
                    }
                    else
                    {
                        List<string> Tokens = Input
                        .Split(new string[] { " = " },
                         StringSplitOptions
                        .RemoveEmptyEntries)
                        .ToList();

                        string TrainName = Tokens[0];
                        string OtherName = Tokens[1];

                        if (!AllTrains.ContainsKey(TrainName))
                        {
                            AllTrains[TrainName] = new List<Wagon>();

                        }

                        List<Wagon> TokenWagons = AllTrains[OtherName];
                        AllTrains[TrainName].AddRange(TokenWagons);
                    }
                }
                Input = Console.ReadLine();
            }

            AllTrains = AllTrains
                 .OrderByDescending(w => w.Value.Sum(x => x.Power))
                 .ThenBy(w => w.Value.Count())
                 .ToDictionary(p => p.Key, p => p.Value);

            foreach (var train in AllTrains)
            {
                string Name = train.Key;
                List<Wagon> Wagons = train.Value;

                Console.WriteLine($"Train: {Name}");

                foreach (var wagon in Wagons.OrderByDescending(w => w.Power))
                {
                    Console.WriteLine($"###{wagon.Name} - {wagon.Power}");
                }
            }
        }
    }
}
