namespace WorkForce.Contracts
{
    using System;

    public interface IEmployee
    {
        string Name { get; }
        int WorkHours { get; }
    }
}
