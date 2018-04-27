using System;
using System.Collections.Generic;
using System.Text;

public interface ICommando : ISpecialisedSoldier
{
    IEnumerable<IMission> Missions { get; }
}
