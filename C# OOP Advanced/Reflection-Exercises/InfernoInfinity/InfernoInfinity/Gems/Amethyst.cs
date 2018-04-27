namespace InfernoInfinity.Gems
{
    public class Amethyst : Gem
    {
        private const int STRENGTH = 2;
        private const int AGILITY = 8;
        private const int VITALITY = 4;

        public Amethyst(string qulityLevel)
            : base(qulityLevel, STRENGTH, AGILITY, VITALITY)
        {
        }
    }
}