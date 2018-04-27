using System;
using System.Collections.Generic;
using System.Text;

public class SpecializedSoldier : Soldier, ISpecialisedSoldier
{
    private string corps;

    public SpecializedSoldier(string id, string firstName, string lastName, 
                              double salary,string corps) 
                       : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }

    public string Corps
    {
        get { return corps; }
        private set { corps = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Corps: {this.Corps}");
        return sb.ToString().Trim();
    }
}
