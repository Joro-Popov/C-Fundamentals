using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HeavyHardware : Hardware
{
    public HeavyHardware(string name, int capacity, int memory) 
        : base(name, capacity, memory)
    {
        this.MaxMemory -= (this.MaxMemory / 4);
        this.MaxCapacity *= 2;
        this.Type = "Heavy";
    }
    
}
