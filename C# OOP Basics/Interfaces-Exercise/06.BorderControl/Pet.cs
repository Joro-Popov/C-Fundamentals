public class Pet : IBirthable
{
    private string birthdate;
    private string name;
    
    public Pet(string name, string birthdate)
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public string Birthdate
    {
        get { return this.birthdate; }
        private set { this.birthdate = value; }
    }
}