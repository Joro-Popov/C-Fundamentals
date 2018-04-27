using System;
using System.Collections.Generic;

public static class HarvesterFactory
{
    public static Harvester CreateHarvest(List<string> args)
    {
        string type = args[0];
        string id = args[1];
        double oreOutput = double.Parse(args[2]);
        double energyRequirement = double.Parse(args[3]);

        switch (type)
        {
            case "Sonic":
                int sonicFactor = int.Parse(args[4]);
                return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);

            case "Hammer": return new HammerHarvester(id, oreOutput, energyRequirement);

            default: throw new ArgumentException();
        }
    }
}
