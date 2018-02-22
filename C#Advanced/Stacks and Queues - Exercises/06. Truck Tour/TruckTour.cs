using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Truck_Tour
{
    public class Pump
    {
        public long PetrolAmount { get; set; }
        public long DistanceToNextPump { get; set; }

        public Pump(long petrol, long distance)
        {
            PetrolAmount = petrol;
            DistanceToNextPump = distance;
        }
    }

    public class TruckTour
    {
        public static void Main()
        {
            int petrolPumps = int.Parse(Console.ReadLine());
            int bestStart = 0;
            bool isEnough = false;

            Queue<Pump> pumps = new Queue<Pump>();

            CreatePlantation(petrolPumps, pumps);

            while (true)
            {
                Pump startPump = pumps.Dequeue();
                pumps.Enqueue(startPump);
                long tankCapacity = startPump.PetrolAmount;
                tankCapacity -= startPump.DistanceToNextPump;
                int count = 1;

                while (tankCapacity >= 0)
                {
                    Pump currentPump = pumps.Dequeue();

                    if (startPump == currentPump)
                    {
                        isEnough = true;
                        break;
                    }
                    pumps.Enqueue(currentPump);
                    tankCapacity += currentPump.PetrolAmount;
                    tankCapacity -= currentPump.DistanceToNextPump;
                    count++;
                }
                if (isEnough)
                {
                    break;
                }
                bestStart += count;
            }
            Console.WriteLine(bestStart);
        }

        public static void CreatePlantation(int petrolPumps, Queue<Pump> pumps)
        {
            for (int index = 0; index < petrolPumps; index++)
            {
                long[] arguments = Console.ReadLine()
                                  .Split(new char[] { ' ' }
                                  ,StringSplitOptions.RemoveEmptyEntries)
                                  .Select(long.Parse)
                                  .ToArray();

                long petrolAmount = arguments[0];
                long distanceToNextPump = arguments[1];

                Pump pump = new Pump(petrolAmount, distanceToNextPump);
                pumps.Enqueue(pump);
            }
        }
    }
}
