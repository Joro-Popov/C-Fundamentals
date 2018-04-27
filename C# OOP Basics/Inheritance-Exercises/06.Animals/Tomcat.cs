public class Tomcat : Cat
{
    public Tomcat(string name, int age, string gender)
        : base(name, age, gender)
    {
        this.Sound = "MEOW";
    }

    protected override string Gender
    {
        get => base.Gender;
        set => base.Gender = "Male";
    }
}