using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LightSoftware : Software
{
    public LightSoftware(string hardware, string name, int capacity, int memory) 
        : base(hardware, name, capacity, memory)
    {
        this.CapacityConsumption += ((this.CapacityConsumption * 2) / 4);
        this.MemoryConsumption -= ((this.MemoryConsumption * 2) / 4);
    }
    
}
