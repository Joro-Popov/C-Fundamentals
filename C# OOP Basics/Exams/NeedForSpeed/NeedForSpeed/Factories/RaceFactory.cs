using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RaceFactory
{
    public Race CreateRace(string type, int length, string route, int prizePool)
    {
        switch (type)
        {
            case "Casual":
                return new CasualRace(length, route, prizePool, new List<Car>());

            case "Drag":
                return new DragRace(length, route, prizePool, new List<Car>());

            case "Drift":
                return new DriftRace(length, route, prizePool, new List<Car>());

            default: throw new ArgumentException();
        }
    }

    public Race CreateRace(string type, int length, string route, int prizePool, int param)
    {
        switch (type)
        {
            case "TimeLimit":
                return new TimeLimitRace(length, route, prizePool, new List<Car>(), param);

            case "Circuit":
                return new CircuitRace(length, route, prizePool, new List<Car>(), param);

            default: throw new ArgumentException();
        }
    }
}
