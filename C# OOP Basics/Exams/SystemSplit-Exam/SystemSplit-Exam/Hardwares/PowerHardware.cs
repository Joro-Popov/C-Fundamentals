using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PowerHardware : Hardware
{
    public PowerHardware(string name, int capacity, int memory) 
        : base(name, capacity, memory)
    {
        this.MaxCapacity -= ((this.MaxCapacity * 3) / 4);
        this.MaxMemory += ((this.MaxMemory * 3) / 4);
        this.Type = "Power";
    }
}
