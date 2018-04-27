namespace WorkForce
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class JobList<T> : IEnumerable<IJob>
        where T : IJob
    {
        private List<IJob> data;

        public JobList()
        {
            this.data = new List<IJob>();
        }

        public void Add(IJob job)
        {
            this.data.Add(job);
        }

        public void OnJobDone(object sender, EventArgs args)
        {
            var currentJob = ((IJob)sender);
            this.data = this.data.Where(j => j.Name != currentJob.Name).ToList();
        }

        public IEnumerator<IJob> GetEnumerator()
        {
            foreach (var item in this.data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
