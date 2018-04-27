using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(Startup);

        var methodsByAuthor = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        foreach (var method in methodsByAuthor)
        {
            if (method.CustomAttributes.Any(n => n.AttributeType == typeof(SoftUniAttribute)))
            {
                var attrs = method.GetCustomAttributes(true);

                foreach (SoftUniAttribute attr in attrs)
                {
                    Console.WriteLine($"{method.Name} is written by {attr.Name}");
                }
            }
        }
    }
}
