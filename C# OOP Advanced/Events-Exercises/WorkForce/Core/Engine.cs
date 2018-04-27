namespace WorkForce
{
    using System;
    using System.Collections.Generic;
    using WorkForce.Contracts;

    public class Engine
    {
        private IInterpretable interpreter;

        public Engine(IInterpretable interpreter)
        {
            this.interpreter = interpreter;
        }

        public void Run()
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] args = command.Split();
                
                this.interpreter.InterpreteCommand(args);
            }
        }
    }
}
