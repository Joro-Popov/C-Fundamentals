public class Kitten : Cat
{
    public Kitten(string name, int age, string gender)
        : base(name, age, gender)
    {
        Sound = "Meow";
    }

    protected override string Gender
    {
        get => base.Gender;
        set => base.Gender = "Female";
    }
}