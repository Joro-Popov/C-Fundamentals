public class Citizen : Person, IBirthable, IIdentifiable
{
    private string id;
    private string birthdate;

    public Citizen(string name,int age, string id) : base(name,age)
    {
        this.Id = id;
    }
    public Citizen(string name, int age, string id,string birthdate)
        :this(name,age,id)

    {
        this.Birthdate = birthdate;
    }
    
    public string Birthdate
    {
        get { return birthdate; }
        private set { birthdate = value; }
    }
    
    public string Id
    {
        get { return id; }
        private set { id = value; }
    }

    public override void BuyFood()
    {
        this.Food += 10;
    }
}