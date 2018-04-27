using System;
using System.Collections.Generic;
using System.Text;

public interface IProvider
{
    string Id { get; }
    double EnergyOutput { get; }
}
