using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Jedi_Meditation
{
    public class Startup
    {
        public static void Main()
        {
            int inputLines = int.Parse(Console.ReadLine());

            List<string> order = new List<string>();
            List<string> masters = new List<string>();
            List<string> knights = new List<string>();
            List<string> padawans = new List<string>();
            List<string> ToshkoSlav = new List<string>();
            List<string> MasterYoda = new List<string>();

            for (int counter = 0; counter < inputLines; counter++)
            {
                List<string> jedis = Console.ReadLine().Split().ToList();

                foreach (var jedi in jedis)
                {
                    if (jedi[0] == 'm') masters.Add(jedi);
                    else if (jedi[0] == 'k') knights.Add(jedi);
                    else if (jedi[0] == 'p') padawans.Add(jedi);
                    else if (jedi[0] == 't' || jedi[0] == 's') ToshkoSlav.Add(jedi);
                    else if (jedi[0] == 'y') MasterYoda.Add(jedi);
                }
                
            }

            if (MasterYoda.Count == 0)
            {
                order.AddRange(ToshkoSlav);
                order.AddRange(masters);
                order.AddRange(knights);
                order.AddRange(padawans);
            }
            else
            {
                order.AddRange(masters);
                order.AddRange(knights);
                order.AddRange(ToshkoSlav);
                order.AddRange(padawans);
            }

            Console.WriteLine(string.Join(" ",order));
        }
    }
}
