using InfernoInfinity.Contracts;
using System.Linq;

namespace InfernoInfinity.Core
{
    public class Engine
    {
        private ICommandInterpreter interpreter;

        public Engine(ICommandInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void Run()
        {
            while (true)
            {
                var args = CommandReader.ReadLine().ToArray();

                var commandName = args[0];

                var result = this.interpreter.InterpretCommand(commandName, args);

                if (result != string.Empty)
                {
                    CommandWriter.WriteLine(result);
                }
            }
        }
    }
}