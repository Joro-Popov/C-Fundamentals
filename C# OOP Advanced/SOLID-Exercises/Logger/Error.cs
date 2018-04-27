using System;
using System.Collections.Generic;
using System.Text;

public class Error : IError
{
    public DateTime DateTime { get; private set; }
    public string Message { get; private set; }
    public ReportLevel ReportLevel { get; private set; }

    public Error(DateTime dateTime, ReportLevel level, string message)
    {
        this.DateTime = dateTime;
        this.ReportLevel = level;
        this.Message = message;
    }
}
