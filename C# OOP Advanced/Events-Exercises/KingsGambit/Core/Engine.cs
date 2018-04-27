namespace KingsGambit.Core
{
    using KingsGambit.Contracts;
    using System;

    public class Engine
    {
        private IInterpreter interpreter;
        private IReader reader;
        private IWriter writer;

        public Engine(IInterpreter interpreter, IReader reader, IWriter writer)
        {
            this.interpreter = interpreter;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;

            while ((command = reader.Read()) != "End")
            {
                string[] args = command.Split();

                this.interpreter.InterpreteCommand(args);
            }
        }
    }
}
