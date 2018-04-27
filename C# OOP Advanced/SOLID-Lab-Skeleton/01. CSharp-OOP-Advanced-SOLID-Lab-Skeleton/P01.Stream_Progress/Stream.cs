using System;
using System.Collections.Generic;
using System.Text;

public abstract class Stream : IStreamable
{
    protected Stream(int length, int bytesSent)
    {
        this.Length = length;
        this.BytesSent = bytesSent;
    }
    public int BytesSent { get; private set; }

    public int Length { get; private set; }
}
