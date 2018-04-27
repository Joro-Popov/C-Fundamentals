using System;
using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Soldier,ILeutenantGeneral
{
    private IEnumerable<IPrivate> privates;

    public LeutenantGeneral(string id, string firstName, string lastName,
                            double salary,IEnumerable<IPrivate>privates) 
                     : base(id, firstName, lastName, salary)
    {
        this.Privates = privates;
    }

    public IEnumerable<IPrivate> Privates
    {
        get { return this.privates; }
        private set { this.privates = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine("Privates:");
        foreach (var priv in this.Privates)
        {
            sb.AppendLine($"  {priv.ToString()}");
        }
        return sb.ToString().Trim();
    }
}
