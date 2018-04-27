using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HardwareFactory
{
    public Hardware CreateHardware(List<string> args)
    {
        string type = args[0];
        string name = args[1];
        int capacity = int.Parse(args[2]);
        int memory = int.Parse(args[3]);

        switch (type)
        {
            case "RegisterPowerHardware":
                return new PowerHardware(name, capacity, memory);

            case "RegisterHeavyHardware":
                return new HeavyHardware(name, capacity, memory);

            default: throw new ArgumentException("Invalid hardware type!");
        }
    }
}
