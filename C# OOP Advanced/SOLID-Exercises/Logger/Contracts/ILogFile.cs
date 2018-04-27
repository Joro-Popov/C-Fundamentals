using System;
using System.Collections.Generic;
using System.Text;

public interface ILogFile
{
    string Path { get; }

    int Size { get; }

    void WriteToFile(string message);
}
