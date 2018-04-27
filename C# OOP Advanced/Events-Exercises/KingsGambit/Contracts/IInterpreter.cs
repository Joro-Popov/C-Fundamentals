namespace KingsGambit.Contracts
{
    using System;

    public interface IInterpreter
    {
        void InterpreteCommand(string[] data);
    }
}
