namespace P03_BarraksWars.Core
{
    using _03BarracksFactory.Contracts;
    using P03_BarraksWars.Attributes;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string commandType = $"P03_BarraksWars.Core.Commands.{commandName.First().ToString().ToUpper() + commandName.Substring(1)}";

            var typeCommand = Type.GetType(commandType);
            
            var command = (IExecutable)Activator.CreateInstance(typeCommand, new object[] { data });

            command = this.InjectDependencies(command);

            if (command == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            return command;
        }

        private IExecutable InjectDependencies(IExecutable command)
        {
            var fields = command
                .GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.GetCustomAttribute<InjectAttribute>() != null)
                .ToArray();

            var commandFields = this
                .GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                var fieldValue = commandFields
                    .First(f => f.FieldType == field.FieldType)
                    .GetValue(this);

                field.SetValue(command, fieldValue);
            }

            return command;
        }
    }
}
