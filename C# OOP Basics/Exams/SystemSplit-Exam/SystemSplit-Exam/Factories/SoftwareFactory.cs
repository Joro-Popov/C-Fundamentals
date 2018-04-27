using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SoftwareFactory
{
    public Software CreateSoftware(List<string> args)
    {
        string type = args[0];
        string componentName = args[1];
        string name = args[2];
        int capacity = int.Parse(args[3]);
        int memory = int.Parse(args[4]);

        switch (type)
        {
            case "RegisterExpressSoftware":
                return new ExpressSoftware(componentName, name, capacity, memory);

            case "RegisterLightSoftware":
                return new LightSoftware(componentName, name, capacity, memory);

            default: throw new ArgumentException("Invalid software");
        }
    }
}
