using System.Collections.Generic;

public class MonumentFactory : IMonumentFactory
{
    public Monument CreateMonument(List<string> args)
    {
        var type = args[0];
        var name = args[1];
        var affinity = long.Parse(args[2]);

        switch (type)
        {
            case "Air": return new AirMonument(name, affinity);
            case "Water": return new WaterMonument(name, affinity);
            case "Fire": return new FireMonument(name, affinity);
            case "Earth": return new EarthMonument(name, affinity);
            default: return null;
        }
    }
}