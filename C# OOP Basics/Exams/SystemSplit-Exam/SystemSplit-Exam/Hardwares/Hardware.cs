using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Hardware : IHardware
{
    private string name;
    private string type;
    private int maxCapacity;
    private int maxMemory;
    private int leftCapacity;
    private int leftMemory;
    private List<Software> softwareComponents;
    
    public Hardware(string name, int capacity, int memory)
    {
        this.Name = name;
        this.MaxCapacity = capacity;
        this.MaxMemory = memory;
        this.LeftCapacity = this.MaxCapacity;
        this.LeftMemory = this.MaxMemory;
        this.SoftwareComponents = new List<Software>();
    }

    public List<Software> SoftwareComponents
    {
        get { return softwareComponents; }
        private set { softwareComponents = value; }
    }

    public int LeftMemory
    {
        get { return leftMemory; }
        protected set { leftMemory = value; }
    }

    public int LeftCapacity
    {
        get { return leftCapacity; }
        protected set { leftCapacity = value; }
    }

    public int MaxMemory
    {
        get { return maxMemory; }
        protected set { maxMemory = value; }
    }

    public int MaxCapacity
    {
        get { return maxCapacity; }
        protected set { maxCapacity = value; }
    }

    public string Type
    {
        get { return type; }
        protected set { type = value; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public void AddSoftware(Software software)
    {
        if (this.LeftCapacity - software.CapacityConsumption >= 0 && 
            this.LeftMemory - software.MemoryConsumption >= 0 )
        {
            this.softwareComponents.Add(software);
            this.LeftCapacity -= software.CapacityConsumption;
            this.LeftMemory -= software.MemoryConsumption;
        }
    }
    
    public void ReleaseSoftware(string software)
    {
        if (this.softwareComponents.Any(s => s.Name == software))
        {
            for (int i = 0; i < this.softwareComponents.Count; i++)
            {
                if (this.softwareComponents[i].Name == software)
                {
                    this.LeftCapacity += this.softwareComponents[i].CapacityConsumption;
                    this.LeftMemory += this.softwareComponents[i].MemoryConsumption;
                    this.softwareComponents.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
