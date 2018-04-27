public class Cat : Animal
{
    private int inteligenceCoefficent;

    public Cat(string name, int age, int inteligenceCoefficent, string adoptionCenter)
        : base(name, age, adoptionCenter)
    {
        this.InteligenceCoefficent = inteligenceCoefficent;
    }

    public int InteligenceCoefficent
    {
        get { return inteligenceCoefficent; }
        private set { inteligenceCoefficent = value; }
    }
}