using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engineer : SpecializedSoldier, IEngineer
{
    private IEnumerable<IRepair> repairs;

    public Engineer(string id, string firstName, string lastName, double salary,
                    string corps, IEnumerable<IRepair> repairs)
                   : base(id, firstName, lastName, salary,corps)
    {
        this.Repairs = repairs;
    }
    
    public IEnumerable<IRepair> Repairs
    {
        get { return this.repairs; }
        private set { this.repairs = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Repairs:");
        foreach (var repair in this.Repairs)
        {
            sb.AppendLine(repair.ToString());
        }
        return sb.ToString().Trim();
    }
}
