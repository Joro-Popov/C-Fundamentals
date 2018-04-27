namespace EventImplementation
{
    using System;

    public interface IDispatcher
    {
        string Name { get; }

        event EventHandler<NameChangeEventArgs> NameChange;

        void OnNameChange(NameChangeEventArgs args);
    }
}