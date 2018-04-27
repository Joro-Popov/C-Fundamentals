using System;
using System.Collections.Generic;
using System.Text;

public class LayoutFactory
{
    public ILayout CreateLayout(string type)
    {
        Layout layout = (Layout)System.Reflection.Assembly
            .GetExecutingAssembly()
            .CreateInstance(type);
        
        return layout;
    }
}
