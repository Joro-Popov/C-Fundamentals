using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Software : ISoftware
{
    private string name;
    private string type;
    private int capacityConsumption;
    private int memoryConsumption;
    private string hardwareComponent;
    
    public Software(string hardware, string name, int capacity, int memory)
    {
        this.HardwareComponent = hardware;
        this.Name = name;
        this.CapacityConsumption = capacity;
        this.MemoryConsumption = memory;
        this.Type = this.GetType().Name;
    }

    public string HardwareComponent
    {
        get { return hardwareComponent; }
        protected set { hardwareComponent = value; }
    }

    public int MemoryConsumption
    {
        get { return memoryConsumption; }
        protected set { memoryConsumption = value; }
    }

    public int CapacityConsumption
    {
        get { return capacityConsumption; }
        protected set { capacityConsumption = value; }
    }

    public string Type
    {
        get { return type; }
        private set { type = value; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public override string ToString()
    {
        return $"{this.Name}";
    }
}
