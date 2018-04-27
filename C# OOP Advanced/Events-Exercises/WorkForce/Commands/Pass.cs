namespace WorkForce.Commands
{
    using System;

    public class Pass : Command
    {
        [Inject]
        private JobList<IJob> jobs;

        public Pass(string[] data) : base(data)
        {

        }

        public override void Execute()
        {
            foreach (var job in jobs)
            {
                job.Update();
            }
        }
    }
}
