using System.Collections.Generic;

public abstract class Center : ICenter
{
    private string name;
    private IEnumerable<Animal> storedAnimals;

    public Center(string name)
    {
        this.Name = name;
        this.StoredAnimals = new List<Animal>();
    }

    public IEnumerable<Animal> StoredAnimals
    {
        get { return storedAnimals; }
        private set { storedAnimals = value; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public void AddAnimal(Animal animal)
    {
        (this.StoredAnimals as List<Animal>).Add(animal);
    }
}