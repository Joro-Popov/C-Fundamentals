using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ExpressSoftware : Software
{
    public ExpressSoftware(string hardware, string name, int capacity, int memory) 
        : base(hardware, name, capacity, memory)
    {
        this.MemoryConsumption *= 2;
    }
    
}
