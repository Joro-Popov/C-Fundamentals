using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Commando : SpecializedSoldier, ICommando
{
    private IEnumerable<IMission> missions;

    public Commando(string id, string firstName, string lastName, double salary,
                    string corps, IEnumerable<IMission> missions) 
                  : base(id, firstName, lastName, salary,corps)
    {
        this.Missions = missions;
    }

    public IEnumerable<IMission> Missions
    {
        get { return this.missions; }
        private set
        {
            this.missions = value;
        }
    }
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Missions:");
        foreach (var mission in this.Missions)
        {
            sb.AppendLine(mission.ToString());
        }
        return sb.ToString().Trim();
    }
}
