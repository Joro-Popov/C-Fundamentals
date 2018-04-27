using System.Collections.Generic;

public interface ICenter
{
    string Name { get; }
    IEnumerable<Animal> StoredAnimals { get; }
}