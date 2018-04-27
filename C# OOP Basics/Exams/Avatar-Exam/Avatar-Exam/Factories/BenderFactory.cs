using System.Collections.Generic;

public class BenderFactory : IBenderFactory
{
    public Bender CreateBender(List<string> args)
    {
        var type = args[0];
        var name = args[1];
        var power = long.Parse(args[2]);
        var secondaryParam = double.Parse(args[3]);

        switch (type)
        {
            case "Air": return new AirBender(name, power, secondaryParam);
            case "Water": return new WaterBender(name, power, secondaryParam);
            case "Fire": return new FireBender(name, power, secondaryParam);
            case "Earth": return new EarthBender(name, power, secondaryParam);
            default: return null;
        }
    }
}