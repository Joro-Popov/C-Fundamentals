using InfernoInfinity.Attributes;
using InfernoInfinity.Contracts;
using InfernoInfinity.Core;
using System;
using System.Linq;
using System.Reflection;

namespace InfernoInfinity
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IWeaponRepository repository;
        private IWeaponFactory weaponFactory;
        private IGemFactory gemFactory;

        public CommandInterpreter(IWeaponRepository repository, IWeaponFactory weaponFactory, IGemFactory gemFactory)
        {
            this.repository = repository;
            this.weaponFactory = weaponFactory;
            this.gemFactory = gemFactory;
        }

        public string InterpretCommand(string commandName, string[] data)
        {
            var fullName = $" InfernoInfinity.Commands.{commandName}";
            
            var type = Type.GetType(fullName);

            if (type == null)
            {
                throw new ArgumentException($"Invalid command {commandName}");
            }

            if (!type.IsAssignableFrom(typeof(IExecutable)))
            {
                throw new ArgumentException($"{commandName} is not a command");
            }

            var command = (IExecutable)Activator.CreateInstance(type, new object[] { data });

            command = InjectDependencies(command);

            return command.Execute();
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