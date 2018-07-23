using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ProviderFactory : IProviderFactory
{
    private const string Suffix = "Provider";

    public IProvider GenerateProvider(IList<string> args)
    {
        int id = int.Parse(args[1]);
        string type = args[0] + Suffix;
        double energyOutput = double.Parse(args[2]);

        Type providerType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

        var ctors = providerType.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

        var provider = (IProvider)ctors.First().Invoke(new object[] { id, energyOutput });

        return provider;
    }
}