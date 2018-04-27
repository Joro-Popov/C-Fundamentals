using System;
using System.Collections.Generic;
using System.Text;

public abstract class Appender : IAppender
{
    protected Appender(ILayout layout, ReportLevel reportLevel)
    {
        this.Layout = layout;
        this.ReportLevel = reportLevel;
        this.AppendedMessages = 0;
    }

    public ReportLevel ReportLevel { get; set; }

    public ILayout Layout { get; set; }

    public int AppendedMessages { get; set; }

    public abstract void AppendMessage(IError error);

    public override string ToString()
    {
        string appenderType = this.GetType().Name;
        string layoutType = this.Layout.GetType().Name;

        return $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {this.ReportLevel}, Messages append: {this.AppendedMessages}";
    }
}
