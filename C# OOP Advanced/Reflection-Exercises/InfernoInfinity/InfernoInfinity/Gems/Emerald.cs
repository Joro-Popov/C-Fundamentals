namespace InfernoInfinity.Gems
{
    public class Emerald : Gem
    {
        private const int STRENGTH = 1;
        private const int AGILITY = 4;
        private const int VITALITY = 9;

        public Emerald(string qulityLevel)
            : base(qulityLevel, STRENGTH, AGILITY, VITALITY)
        {
        }
    }
}