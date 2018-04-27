using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Corporation
{
    private Dictionary<string, CleansingCenter> cleansingCenters;
    private Dictionary<string, AdoptionCenter> adoptionCenters;
    private Dictionary<string, CastrationCenter> castrationCenters;

    private List<Animal> adopted;
    private List<Animal> cleansed;
    private List<Animal> castrated;

    public Corporation()
    {
        this.CleansingCenters = new Dictionary<string, CleansingCenter>();
        this.AdoptionCenters = new Dictionary<string, AdoptionCenter>();
        this.CastrationCenters = new Dictionary<string, CastrationCenter>();
        this.Adopted = new List<Animal>();
        this.Cleansed = new List<Animal>();
        this.Castrated = new List<Animal>();
    }

    public List<Animal> Castrated
    {
        get { return castrated; }
        set { castrated = value; }
    }

    public List<Animal> Cleansed
    {
        get { return cleansed; }
        set { cleansed = value; }
    }

    public List<Animal> Adopted
    {
        get { return adopted; }
        set { adopted = value; }
    }

    public Dictionary<string, CastrationCenter> CastrationCenters
    {
        get { return castrationCenters; }
        private set { castrationCenters = value; }
    }

    public Dictionary<string, AdoptionCenter> AdoptionCenters
    {
        get { return adoptionCenters; }
        private set { adoptionCenters = value; }
    }

    public Dictionary<string, CleansingCenter> CleansingCenters
    {
        get { return cleansingCenters; }
        private set { cleansingCenters = value; }
    }

    public void RegisterCleansingCenter(string name)
    {
        CleansingCenter current = new CleansingCenter(name);
        this.CleansingCenters[name] = current;
    }

    public void RegisterAdoptionCenter(string name)
    {
        AdoptionCenter current = new AdoptionCenter(name);
        this.AdoptionCenters[name] = current;
    }

    public void RegisterAnimal(Animal animal)
    {
        this.AdoptionCenters[animal.AdoptionCenter].AddAnimal(animal);
    }

    public void SendForClean(string adoptionCenter, string cleansingCenter)
    {
        this.AdoptionCenters[adoptionCenter].SendForClean(this.CleansingCenters[cleansingCenter]);
    }

    public void Cleanse(string cleansingCenter)
    {
        this.cleansingCenters[cleansingCenter].CleanAnimals(this.cleansed);
        this.cleansingCenters[cleansingCenter].ReturnToAdoptionCenter(this.adoptionCenters);
    }

    public void Adopt(string adoptionCenter)
    {
        this.adoptionCenters[adoptionCenter].AdoptAnimals(this.adopted);
    }

    public void RegisterCastrationCenter(string name)
    {
        CastrationCenter current = new CastrationCenter(name);
        this.castrationCenters[name] = current;
    }

    public void SendForCastration(string adoptionCenter, string castrationCenter)
    {
        this.AdoptionCenters[adoptionCenter].SendForCastration(this.castrationCenters[castrationCenter]);
    }

    public void Castrate(string castrationCenter)
    {
        this.CastrationCenters[castrationCenter].Castrate(Castrated, this.adoptionCenters);
    }

    public string PrintCastrationStatistics()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Paw Inc. Regular Castration Statistics");
        sb.AppendLine($"Castration Centers: {this.CastrationCenters.Count}");
        if (this.Castrated.Count == 0)
        {
            sb.AppendLine($"Castrated Animals: None");
        }
        else
        {
            sb.AppendLine($"Castrated Animals: {string.Join(", ", this.Castrated.OrderBy(a => a.Name))}");
        }

        return sb.ToString().Trim();
    }

    public override string ToString()
    {
        int awaitingAdoption = this.AdoptionCenters.Sum(a => a.Value.StoredAnimals.Where(b => b.CleansingStatus == "CLEANSED").Count());
        int awaitingCleanse = this.CleansingCenters.Sum(a => a.Value.StoredAnimals.Where(b => b.CleansingStatus == "UNCLEANSED").Count());

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Paw Incorporative Regular Statistics");
        sb.AppendLine($"Adoption Centers: {this.AdoptionCenters.Count}");
        sb.AppendLine($"Cleansing Centers: {this.CleansingCenters.Count}");

        if (this.adopted.Count == 0)
        {
            sb.AppendLine($"Adopted Animals: None");
        }
        else
        {
            sb.AppendLine($"Adopted Animals: {string.Join(", ", this.adopted.OrderBy(a => a.Name))}");
        }

        if (this.cleansed.Count == 0)
        {
            sb.AppendLine($"Cleansed Animals: None");
        }
        else
        {
            sb.AppendLine($"Cleansed Animals: {string.Join(", ", this.cleansed.OrderBy(a => a.Name))}");
        }
        sb.AppendLine($"Animals Awaiting Adoption: {awaitingAdoption}");
        sb.AppendLine($"Animals Awaiting Cleansing: {awaitingCleanse}");

        return sb.ToString().Trim();
    }
}