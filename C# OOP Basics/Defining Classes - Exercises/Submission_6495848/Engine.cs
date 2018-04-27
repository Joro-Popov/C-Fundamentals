using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    public string Model { get; set; }
    public string Power { get; set; }
    public string Displacement { get; set; }
    public string Efficiency { get; set; }

    private Engine()
    {
        this.Displacement = "n/a";
        this.Efficiency = "n/a";
    }
    public Engine(List<string> engineTokens):this()
    {
        this.Model = engineTokens[0];
        this.Power = engineTokens[1];

        if (engineTokens.Count.Equals(4))
        {
            this.Displacement = engineTokens[2];
            this.Efficiency = engineTokens[3];
        }
        else if (engineTokens.Count.Equals(3))
        {
            try
            {
                int token = int.Parse(engineTokens[2]);
                this.Displacement = engineTokens[2];
            }
            catch (Exception)
            {
                this.Efficiency = engineTokens[2];
            }
        }
    }
}
