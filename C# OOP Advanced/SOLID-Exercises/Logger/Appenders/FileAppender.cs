using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class FileAppender : Appender
{
    public FileAppender(ILayout layout, ReportLevel reportLevel, LogFile logFile) 
        : base(layout, reportLevel)
    {
        this.LogFile = logFile;
    }

    public ILogFile LogFile { get; set; }

    public override void AppendMessage(IError error)
    {
        string output = this.Layout.FormatError(error);
        LogFile.WriteToFile(output);
        this.AppendedMessages++;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, File size: {this.LogFile.Size}";
    }
}
