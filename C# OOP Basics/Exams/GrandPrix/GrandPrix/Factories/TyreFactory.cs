using System;
using System.Collections.Generic;

public class TyreFactory
{
    public Tyre CreateTyre(List<string> args)
    {
        string type = args[0];
        double tyreHardness = double.Parse(args[1]);

        switch (type)
        {
            case "Ultrasoft":
                double grip = double.Parse(args[2]);
                return new UltrasoftTyre(tyreHardness, grip);

            case "Hard":
                return new HardTyre(tyreHardness);

            default: throw new ArgumentException();
        }
    }
}