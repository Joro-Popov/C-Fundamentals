using System.Collections.Generic;
using System.Linq;

public class CastrationCenter : Center
{
    public CastrationCenter(string name) : base(name)
    {
    }

    public void Castrate(List<Animal> castrated, Dictionary<string, AdoptionCenter> adoptionCenters)
    {
        for (int index = 0; index < this.StoredAnimals.Count(); index++)
        {
            Animal current = (this.StoredAnimals as List<Animal>)[index];
            current.Castrated = true;
            adoptionCenters[current.AdoptionCenter].AddAnimal(current);
            castrated.Add(current);
        }
        (this.StoredAnimals as List<Animal>).Clear();
    }
}