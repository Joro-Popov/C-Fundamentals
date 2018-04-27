using System.Collections.Generic;
using System.Linq;

public class Nation
{
    public Nation()
    {
        this.Benders = new List<Bender>();
        this.Monuments = new List<Monument>();
    }

    public List<Bender> Benders { get; private set; }

    public List<Monument> Monuments { get; private set; }

    public double GetTotalPower()
    {
        var benderPower = this.Benders.Sum(b => b.GetPower());
        var monumentPower = this.Monuments.Sum(m => m.Affinity);
        var totalBonus = (benderPower / 100) * monumentPower;
        var totalPower = benderPower + totalBonus;

        return totalPower;
    }
}