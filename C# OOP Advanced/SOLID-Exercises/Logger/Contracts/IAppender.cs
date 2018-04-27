using System;
using System.Collections.Generic;
using System.Text;

public interface IAppender
{
    ILayout Layout { get; }

    ReportLevel ReportLevel { get; }

    int AppendedMessages { get; }

    void AppendMessage(IError error);
}
