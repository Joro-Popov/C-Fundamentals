namespace Forum.App.Factories
{
	using Contracts;
    using System;
    using System.Reflection;
    using System.Linq;

    public class CommandFactory : ICommandFactory
	{
        private IServiceProvider serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

		public ICommand CreateCommand(string commandName)
		{
            Assembly assembly = Assembly.GetExecutingAssembly();

            var commandType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name == commandName + "Command");

            if (assembly == null)
            {
                throw new InvalidOperationException("Command not found!");
            }
            if (!typeof(ICommand).IsAssignableFrom(commandType))
            {
                throw new InvalidOperationException($"{commandType} is not a commnd!");
            }

            var ctrorParams = commandType.GetConstructors().First().GetParameters();

            object[] args = new object[ctrorParams.Length];

            for (int counter = 0; counter < args.Length; counter++)
            {
                args[counter] = this
                    .serviceProvider
                    .GetService(ctrorParams[counter].ParameterType);
            }

            var command = (ICommand)Activator.CreateInstance(commandType, args);

            return command;
        }
	}
}
