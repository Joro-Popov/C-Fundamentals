public class Dog : Animal
{
    private int learnedCommands;

    public Dog(string name, int age, int learnedCommands, string adoptionCenter)
        : base(name, age, adoptionCenter)
    {
        this.LearnedCommands = learnedCommands;
    }

    public int LearnedCommands
    {
        get { return learnedCommands; }
        private set { learnedCommands = value; }
    }
}