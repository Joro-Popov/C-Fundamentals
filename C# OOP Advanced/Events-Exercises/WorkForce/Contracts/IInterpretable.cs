namespace WorkForce.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IInterpretable
    {
        void InterpreteCommand(IEnumerable<string> args);
    }
}
