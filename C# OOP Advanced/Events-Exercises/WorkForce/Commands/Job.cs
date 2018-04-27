namespace WorkForce.Commands
{
    using System;
    using System.Collections.Generic;
    using WorkForce.Contracts;

    public class Job : Command
    {
        [Inject]
        private IDictionary<string, IEmployee> employees;

        [Inject]
        private JobList<IJob> jobs;

        public Job(string[] data) : base(data)
        {

        }

        public override void Execute()
        {
            string name = this.Data[1];
            int hoursRequired = int.Parse(this.Data[2]);
            string employeeName = this.Data[3];
            var employee = this.employees[employeeName];
            var type = typeof(WorkForce.Job);
            var job = (IJob)Activator.CreateInstance(type, new object[] { name, hoursRequired, employee });
            this.jobs.Add(job);
            job.JobDone += this.jobs.OnJobDone;
        }
    }
}
