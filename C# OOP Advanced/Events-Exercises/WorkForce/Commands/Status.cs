namespace WorkForce.Commands
{
    using System;

    public class Status : Command
    {
        [Inject]
        private JobList<IJob> jobs;

        public Status(string[] data) : base(data)
        {

        }

        public override void Execute()
        {
            foreach (var job in this.jobs)
            {
                Console.WriteLine(job);
            }
        }
    }
}
