using System;
using System.Collections.Generic;
using System.Text;

public abstract class Layout : ILayout
{
    protected const string DATE_FORMAT = "M/d/yyyy h:mm:sm tt";

    protected Layout()
    {
        
    }
    
    public abstract string FormatError(IError error);
}
