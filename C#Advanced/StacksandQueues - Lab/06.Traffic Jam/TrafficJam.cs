using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _06.Traffic_Jam
{
    public class TrafficJam
    {
        public static void Main()
        {
            int carsThatCanPass = int.Parse(Console.ReadLine());
            string currentCar = Console.ReadLine();
            int carsCounter = 0;

            Queue<string> cars = new Queue<string>();

            while (currentCar != "end")
            {
                if (currentCar == "green")
                {
                    int counter = Math.Min(carsThatCanPass, cars.Count);

                    for (int i = 0; i < counter; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        carsCounter++;
                    }
                }
                else
                {
                    cars.Enqueue(currentCar);
                }

                currentCar = Console.ReadLine();
            }
            Console.WriteLine($"{carsCounter} cars passed the crossroads.");
        }
    }
}
