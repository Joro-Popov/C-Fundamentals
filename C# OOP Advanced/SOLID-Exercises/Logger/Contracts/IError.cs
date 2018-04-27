using System;
using System.Collections.Generic;
using System.Text;

public interface IError
{
    DateTime DateTime { get; }

    string Message { get; }
    
    ReportLevel ReportLevel { get; }
}
