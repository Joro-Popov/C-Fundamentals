namespace WorkForce
{
    using System;
    using System.Collections.Generic;
    using WorkForce.Contracts;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : IInterpretable
    {
        private IDictionary<string, IEmployee> employees;
        private JobList<IJob> jobs;

        public CommandInterpreter(IDictionary<string, IEmployee> employees, JobList<IJob> jobs)
        {
            this.employees = employees;
            this.jobs = jobs;
        }

        public void InterpreteCommand(IEnumerable<string> args)
        {
            string commandName = args.ElementAt(0);
            string fullName = $"WorkForce.Commands.{commandName}";
            var type = Type.GetType(fullName);

            var command = (IExecutable)Activator.CreateInstance(type, new object[] { args });

            command = InjectDependencies(command);
            
            command.Execute();
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
