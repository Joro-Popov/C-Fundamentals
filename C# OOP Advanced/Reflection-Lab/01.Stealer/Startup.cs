using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

public class Startup
{
    static void Main()
    {
        Spy spy = new Spy();
        string result = spy.CollectGettersAndSetters("Hacker");
        Console.WriteLine(result);
    }
}
