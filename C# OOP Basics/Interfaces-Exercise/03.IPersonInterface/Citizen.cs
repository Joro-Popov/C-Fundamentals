public class Citizen : IPerson, IIdentifiable, IBirthable
{
    private string name;
    private int age;
    private string id;
    private string birthdate;

    public Citizen(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public Citizen(string name, int age, string id, string birthdate)
        :this(name,age)
    {
        this.Id = id;
        this.Birthdate = birthdate;
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

    public string Id
    {
        get { return this.id; }
        private set { this.id = value; }
    }

    public string Birthdate
    {
        get { return this.birthdate; }
        private set { this.birthdate = value; }
    }
}