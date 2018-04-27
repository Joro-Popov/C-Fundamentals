namespace WorkForce
{
    using System;
    using WorkForce.Contracts;

    public class Job : IJob
    {
        private IEmployee employee;
        private int requiredWorkHours;

        public event EventHandler<EventArgs> JobDone;

        public Job(string name, int requiredHours,IEmployee employee)
        {
            this.employee = employee;
            this.Name = name;
            this.requiredWorkHours = requiredHours;
        }

        public string Name { get; private set; }

        protected virtual void OnUpdate()
        {
            this.JobDone?.Invoke(this, EventArgs.Empty);
        }

        public void Update()
        {
            this.requiredWorkHours -= this.employee.WorkHours;

            if (this.requiredWorkHours <= 0)
            {
                Console.WriteLine($"Job {this.Name} done!");
                this.OnUpdate();
            }
        }

        public override string ToString()
        {
            string output = $"Job: {this.Name} Hours Remaining: {this.requiredWorkHours}";

            return output;
        }
    }
}
