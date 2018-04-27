using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private BenderFactory benderFactory;
    private MonumentFactory monumentFactory;
    private List<string> nationsIssuedWar;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>();
        this.benderFactory = new BenderFactory();
        this.monumentFactory = new MonumentFactory();
        this.nationsIssuedWar = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        var benderType = benderArgs[0];

        var bender = this.benderFactory.CreateBender(benderArgs);

        if (!nations.ContainsKey(benderType))
        {
            this.nations[benderType] = new Nation();
        }

        this.nations[benderType].Benders.Add(bender);
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        var monumentType = monumentArgs[0];

        var monument = this.monumentFactory.CreateMonument(monumentArgs);

        if (!this.nations.ContainsKey(monumentType))
        {
            this.nations[monumentType] = new Nation();
        }
        this.nations[monumentType].Monuments.Add(monument);
    }

    public string GetStatus(string nationsType)
    {
        var result = new StringBuilder();

        if (this.nations.ContainsKey(nationsType))
        {
            var nation = this.nations[nationsType];

            result.AppendLine($"{nationsType} Nation");

            if (!nation.Benders.Any())
            {
                result.AppendLine("Benders: None");
            }
            else
            {
                result.AppendLine("Benders:");

                foreach (var bender in nation.Benders)
                {
                    result.AppendLine($"###{bender}");
                }
            }

            if (!nation.Monuments.Any())
            {
                result.AppendLine("Monuments: None");
            }
            else
            {
                result.AppendLine("Monuments:");

                foreach (var monument in nation.Monuments)
                {
                    result.AppendLine($"###{monument}");
                }
            }

            return result.ToString().Trim();
        }
        return string.Empty;
    }

    public void IssueWar(string nationsType)
    {
        this.nationsIssuedWar.Add(nationsType);

        this.nations = this.nations.OrderByDescending(n => n.Value.GetTotalPower()).ToDictionary(k => k.Key, v => v.Value);

        foreach (var nation in this.nations.Skip(1))
        {
            nation.Value.Benders.Clear();
            nation.Value.Monuments.Clear();
        }
    }

    public string GetWarsRecord()
    {
        var result = new StringBuilder();
        var index = 1;

        foreach (var nation in this.nationsIssuedWar)
        {
            result.AppendLine($"War {index} issued by {nation}");

            index++;
        }

        return result.ToString().Trim();
    }
}