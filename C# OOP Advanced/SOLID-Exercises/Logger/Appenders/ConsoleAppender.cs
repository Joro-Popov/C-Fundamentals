using System;
using System.Collections.Generic;
using System.Text;

public class ConsoleAppender : Appender
{
    public ConsoleAppender(ILayout layout,ReportLevel reportLevel) 
        : base(layout, reportLevel)
    {
    }

    public override void AppendMessage(IError error)
    {
        string output = this.Layout.FormatError(error);
        Console.WriteLine(output);
        this.AppendedMessages++;
    }
}
