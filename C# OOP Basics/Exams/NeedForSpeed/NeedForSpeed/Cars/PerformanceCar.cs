using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PerformanceCar : Car
{
    private IEnumerable<string> addOns;
    
    public PerformanceCar(string brand, string model, int prodYear, int hp, int acceleration, int suspension, int durability, ICollection<string> addOns) 
        : base(brand, model, prodYear, hp, acceleration, suspension, durability)
    {
        this.AddOns = addOns;
        this.Horsepower += (this.Horsepower * 50) / 100;
        this.Suspension -= (this.Suspension * 25) / 100;
    }

    public IEnumerable<string> AddOns
    {
        get { return addOns; }
        private set { addOns = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        if (this.AddOns.Count() == 0)
        {
            sb.AppendLine("Add-ons: None");
        }
        else
        {
            sb.AppendLine($"Add-ons: {string.Join(", ", this.AddOns)}");
        }

        return sb.ToString().Trim();
    }

    public void IncreaseAddOns(string addOn)
    {
        (this.AddOns as List<string>).Add(addOn);
    }
}
