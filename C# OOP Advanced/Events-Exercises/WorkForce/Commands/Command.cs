namespace WorkForce.Commands
{
    using System;
    using System.Collections.Generic;
    using WorkForce.Contracts;

    public abstract class Command : IExecutable
    {
        protected Command(string[] data)
        {
            this.Data = data;
        }

        public string[] Data { get; set; }

        public abstract void Execute();
    }
}
