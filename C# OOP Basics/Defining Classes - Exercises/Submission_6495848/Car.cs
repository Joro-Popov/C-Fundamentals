using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public string Weight { get; set; }
    public string Color { get; set; }

    private Car()
    {
        this.Weight = "n/a";
        this.Color = "n/a";
    }
    public Car(List<string>carTokens,Dictionary<string,Engine>engines):this()
    {
        this.Model = carTokens[0];
        this.Engine = engines[carTokens[1]];

        if (carTokens.Count.Equals(4))
        {
            this.Weight = carTokens[2];
            this.Color = carTokens[3];
        }
        else if (carTokens.Count.Equals(3))
        {
            try
            {
                int weightToken = int.Parse(carTokens[2]);
                this.Weight = carTokens[2];
            }
            catch (Exception)
            {
                this.Color = carTokens[2];
            }
        }
    }
}
