using InfernoInfinity.Contracts;

namespace InfernoInfinity.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;

        protected Command()
        {
        }

        protected Command(string[] data) : this()
        {
            this.data = data;
        }

        protected string[] Data => this.data;

        public abstract string Execute();
    }
}