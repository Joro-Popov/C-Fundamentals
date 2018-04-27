public abstract class Animal : IAnimal
{
    private string name;
    private int age;
    private string cleansingStatus;
    private string adoptionCenter;
    private bool castrated;

    public Animal(string name, int age, string adoptionCenter)
    {
        this.Name = name;
        this.Age = age;
        this.AdoptionCenter = adoptionCenter;
        this.CleansingStatus = "UNCLEANSED";
        this.Castrated = false;
    }

    public bool Castrated
    {
        get { return castrated; }
        set { castrated = value; }
    }

    public string AdoptionCenter
    {
        get { return adoptionCenter; }
        private set { adoptionCenter = value; }
    }

    public string CleansingStatus
    {
        get { return cleansingStatus; }
        set { cleansingStatus = value; }
    }

    public int Age
    {
        get { return age; }
        private set { age = value; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public override string ToString()
    {
        return $"{this.Name}";
    }
}