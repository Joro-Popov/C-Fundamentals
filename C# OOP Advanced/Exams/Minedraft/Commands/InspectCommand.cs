using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class InspectCommand : Command
{
    private const string Harvesters = "harvesters";
    private const string Providers = "providers";

    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string result = string.Empty;

        var id = int.Parse(this.Arguments[0]);

        var harvesters = (IList<IHarvester>)this.harvesterController
            .GetType()
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(f => f.Name == Harvesters)
            .GetValue(this.harvesterController);

        var providers = (IList<IProvider>)this.providerController
            .GetType()
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(f => f.Name == Providers)
            .GetValue(this.providerController);

        bool harvesterWithIdExists = harvesters.Any(h => h.ID == id);
        bool providerWithIdExists = providers.Any(p => p.ID == id);

        if (harvesterWithIdExists)
        {
            var harvester = harvesters.FirstOrDefault(h => h.ID == id);
            result = string.Format(Constants.EntityInfo, harvester.GetType().FullName, harvester.Durability);
        }
        else if (providerWithIdExists)
        {
            var provider = providers.FirstOrDefault(p => p.ID == id);
            result = string.Format(Constants.EntityInfo, provider.GetType().FullName, provider.Durability);
        }
        else
        {
            result = string.Format(Constants.NoEntityFound, id);
        }

        return result;
    }
}