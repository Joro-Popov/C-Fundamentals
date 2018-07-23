using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string Suffix = "Command";

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; private set; }

    public IProviderController ProviderController { get; private set; }

    public string ProcessCommand(IList<string> arguments)
    {
        var command = this.CreateCommand(arguments);

        var result = command.Execute();

        return result;
    }

    private ICommand CreateCommand(IList<string> arguments)
    {
        var commandName = arguments[0] + Suffix;

        var commandType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == commandName);

        if (commandType == null)
        {
            throw new ArgumentException(string.Format(Constants.CommandNotFound, commandName));
        }

        if (!typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new InvalidOperationException(string.Format(Constants.InvalidCommand, commandName));
        }

        var parametersInfo = commandType.GetConstructors().First().GetParameters();

        var ctorParams = new object[parametersInfo.Length];

        for (int i = 0; i < ctorParams.Length; i++)
        {
            var paramType = parametersInfo[i].ParameterType;

            if (paramType == typeof(IList<string>))
            {
                ctorParams[i] = arguments.Skip(1).ToList();
            }
            else
            {
                var paramInfo = this.GetType().GetProperties()
                    .FirstOrDefault(p => p.PropertyType == paramType);

                ctorParams[i] = paramInfo.GetValue(this);
            }
        }

        var command = (ICommand)Activator.CreateInstance(commandType, ctorParams);

        return command;
    }
}