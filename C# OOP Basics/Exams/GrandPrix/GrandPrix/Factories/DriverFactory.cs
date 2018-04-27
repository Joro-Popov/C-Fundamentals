using System;
using System.Collections.Generic;
using System.Linq;

public class DriverFactory
{
    public Driver CreateDriver(List<string> args, TyreFactory tyreFactory)
    {
        string type = args[0];
        string name = args[1];
        int hp = int.Parse(args[2]);
        double fuelAmount = double.Parse(args[3]);
        List<string> tyreArgs = args.Skip(4).ToList();

        Tyre tyre = tyreFactory.CreateTyre(tyreArgs);
        Car car = new Car(hp, fuelAmount, tyre);

        switch (type)
        {
            case "Aggressive":
                return new AggressiveDriver(name, car);

            case "Endurance":
                return new EnduranceDriver(name, car);

            default: throw new ArgumentException();
        }
    }
}