using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HarvesterFactory : IHarvesterFactory
{
    private const string Suffix = "Harvester";

    public IHarvester GenerateHarvester(IList<string> args)
    {
        var type = args[0] + Suffix;
        var id = int.Parse(args[1]);
        var oreOutput = double.Parse(args[2]);
        var energyReq = double.Parse(args[3]);

        var harvesterType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

        var ctors = harvesterType.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

        var harvester = (IHarvester)ctors.First().Invoke(new object[] { id, oreOutput, energyReq });

        return harvester;
    }
}