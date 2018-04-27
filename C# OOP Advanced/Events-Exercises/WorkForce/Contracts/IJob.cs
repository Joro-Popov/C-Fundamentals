using System;

namespace WorkForce
{
    public interface IJob
    {
        string Name { get; }

        event EventHandler<EventArgs> JobDone;

        void Update();
    }
}