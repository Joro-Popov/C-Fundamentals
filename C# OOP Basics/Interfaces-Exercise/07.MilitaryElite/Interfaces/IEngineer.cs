using System;
using System.Collections.Generic;
using System.Text;

public interface IEngineer : ISpecialisedSoldier
{
    IEnumerable<IRepair> Repairs { get; }
}
