using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        var engines = new Dictionary<string, Engine>();
        var cars = new Dictionary<string, Car>();

        int N = int.Parse(Console.ReadLine());
        for (int index = 0; index < N; index++)
        {
            List<string> engineTokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Engine engine = new Engine(engineTokens);
            engines[engine.Model] = engine;
        }
        int M = int.Parse(Console.ReadLine());
        for (int index = 0; index < M; index++)
        {
            List<string> carTokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Car car = new Car(carTokens, engines);
            cars[car.Model] = car;
        }

        foreach (var car in cars)
        {
            Car currentCar = car.Value;
            Engine currentEngine = currentCar.Engine;

            Console.WriteLine($"{currentCar.Model}:");
            Console.WriteLine($"  {currentEngine.Model}:");
            Console.WriteLine($"    Power: {currentEngine.Power}");
            Console.WriteLine($"    Displacement: {currentEngine.Displacement}");
            Console.WriteLine($"    Efficiency: {currentEngine.Efficiency}");
            Console.WriteLine($"  Weight: {currentCar.Weight}");
            Console.WriteLine($"  Color: {currentCar.Color}");
        }
    }
}
