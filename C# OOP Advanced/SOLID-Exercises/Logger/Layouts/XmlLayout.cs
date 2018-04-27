using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

public class XmlLayout : Layout
{
    const string OUTPUT_FORMAT = 
        "<log>\r\n" +
        "   <date>{0}</date>\r\n" +
        "   <level>{1}</level>\r\n" +
        "   <message>{2}</message>\r\n" +
        "</log>\r\n";
    
    public override string FormatError(IError error)
    {
        string date = error.DateTime.ToString(DATE_FORMAT, CultureInfo.InvariantCulture);
        string output = string.Format(OUTPUT_FORMAT, date, error.ReportLevel, error.Message);
        return output;
    }
    
}
