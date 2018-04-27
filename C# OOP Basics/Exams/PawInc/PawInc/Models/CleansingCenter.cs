using System.Collections.Generic;
using System.Linq;

public class CleansingCenter : Center
{
    public CleansingCenter(string name)
        : base(name)
    {
    }

    public void CleanAnimals(List<Animal> cleansed)
    {
        if (this.StoredAnimals.Count() > 0)
        {
            for (int index = 0; index < this.StoredAnimals.Count(); index++)
            {
                Animal current = (this.StoredAnimals as List<Animal>)[index];
                current.CleansingStatus = "CLEANSED";
                cleansed.Add(current);
            }
        }
    }

    public void ReturnToAdoptionCenter(Dictionary<string, AdoptionCenter> adoptionCenters)
    {
        for (int index = 0; index < this.StoredAnimals.Count(); index++)
        {
            Animal current = (this.StoredAnimals as List<Animal>)[index];
            adoptionCenters[current.AdoptionCenter].AddAnimal(current);
        }
        (this.StoredAnimals as List<Animal>).Clear();
    }
}