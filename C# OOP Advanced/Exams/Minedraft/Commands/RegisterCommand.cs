using System.Collections.Generic;

public class RegisterCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var result = string.Empty;
        this.Arguments.RemoveAt(0);

        if (this.Arguments.Count == 4)
        {
            result = this.harvesterController.Register(this.Arguments);
        }
        else
        {
            result = this.providerController.Register(this.Arguments);
        }

        return result;
    }
}