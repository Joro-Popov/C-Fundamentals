using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Hornet_Armada
{
    public class Soldiers
    {
        public string Type { get; set; }
        public long Count { get; set; }

        public Soldiers(string type, long count)
        {
            Type = type;
            Count = count;
        }
    }
    public class HornetArmada
    {
        public static void AddSoldiersCount(Dictionary<string, List<Soldiers>> legions, string legionName, string soldierType, long soldierCount)
        {
            foreach (var soldier in legions[legionName])
            {
                if (soldier.Type == soldierType)
                {
                    soldier.Count += soldierCount;
                }
            }
        }

        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            var legions = new Dictionary<string,List<Soldiers>>();
            var activities = new Dictionary<string, long>();

            for (int i = 0; i < count; i++)
            {
                string soldierInfo = Console.ReadLine();
                
                List<string> token = soldierInfo
                    .Split(new char[] { '=', '-', '>', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                long lastActivity = long.Parse(token[0]);
                string legionName = token[1];
                string soldierType = token[2];
                long soldierCount = long.Parse(token[3]);

                Soldiers currentSoldiers = new Soldiers(soldierType, soldierCount);

                if (!legions.ContainsKey(legionName))
                {
                    legions[legionName] = new List<Soldiers>();
                    legions[legionName].Add(currentSoldiers);
                    activities[legionName] = lastActivity;
                }
                else
                {
                    if (!legions[legionName].Any(s => s.Type == soldierType))
                    {
                        legions[legionName].Add(currentSoldiers);
                        
                    }
                    else
                    {
                        AddSoldiersCount(legions, legionName, soldierType, soldierCount);
                    }
                }

                if (lastActivity > activities[legionName])
                {
                    activities[legionName] = lastActivity;
                }
            }

            string outputCommand = Console.ReadLine();

            if (outputCommand.Length == 1)
            {

            }
            else
            {
                List<string> tokens = outputCommand.Split('\\').ToList();

                long activity = long.Parse(tokens[0]);
                string type = tokens[1];

                activities = activities
                    .Where(a => a.Value < activity)
                    .ToDictionary(a => a.Key, a => a.Value);
                
                var filtered = new Dictionary<string, List<Soldiers>>();

                foreach (var act in activities)
                {
                    filtered[act.Key] = legions[act.Key];
                }
                

                foreach (var legion in filtered.OrderByDescending(w => w.Value.Sum(s => s.Count)))
                {
                    List<Soldiers> soldiers = legion.Value.Where(w => w.Type == type).ToList();
                }
            }
        }
        
    }
}
