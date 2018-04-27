namespace KingsGambit.Contracts
{
    using System;

    public interface IWriter
    {
        void Write();
        void Write(object obj);
    }
}
