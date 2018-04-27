using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IHardware
{
    string Name { get; }
    string Type { get; }
    int MaxCapacity { get; }
    int MaxMemory { get; }
}
