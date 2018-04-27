using System.Collections.Generic;
using System.Linq;

public class AdoptionCenter : Center
{
    public AdoptionCenter(string name)
        : base(name)
    {
    }

    public void SendForClean(CleansingCenter cleanseCenter)
    {
        if (this.StoredAnimals.Count() > 0)
        {
            (cleanseCenter.StoredAnimals as List<Animal>).AddRange(this.StoredAnimals.Where(a => a.CleansingStatus == "UNCLEANSED"));

            for (int index = 0; index < this.StoredAnimals.Count(); index++)
            {
                Animal current = (this.StoredAnimals as List<Animal>)[index];

                if (current.CleansingStatus == "UNCLEANSED")
                {
                    (this.StoredAnimals as List<Animal>).RemoveAt(index);
                    index--;
                }
            }
        }
    }

    public void SendForCastration(CastrationCenter castrationCenter)
    {
        (castrationCenter.StoredAnimals as List<Animal>).AddRange(this.StoredAnimals);
        (this.StoredAnimals as List<Animal>).Clear();
    }

    public void AdoptAnimals(List<Animal> adopted)
    {
        if (this.StoredAnimals.Count() > 0)
        {
            for (int index = 0; index < this.StoredAnimals.Count(); index++)
            {
                Animal current = (this.StoredAnimals as List<Animal>)[index];

                if (current.CleansingStatus == "CLEANSED")
                {
                    adopted.Add(current);
                    (this.StoredAnimals as List<Animal>).RemoveAt(index);
                    index--;
                }
            }
        }
    }
}