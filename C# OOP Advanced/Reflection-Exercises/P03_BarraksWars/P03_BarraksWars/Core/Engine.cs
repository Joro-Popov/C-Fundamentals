namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;
    using P03_BarraksWars.Core;

    class Engine : IRunnable
    {
        private ICommandInterpreter interpreter;

        public Engine(ICommandInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }
        
        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "fight")
            {
                try
                {
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private string InterpredCommand(string[] data, string commandName)
        {
            var command = this.interpreter.InterpretCommand(data, commandName);

            string result = command.Execute();

            return result;
        }
    }
}
