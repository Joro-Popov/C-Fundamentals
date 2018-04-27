namespace InfernoInfinity.Gems
{
    public class Ruby : Gem
    {
        private const int STRENGTH = 7;
        private const int AGILITY = 2;
        private const int VITALITY = 5;

        public Ruby(string qulityLevel)
            : base(qulityLevel, STRENGTH, AGILITY, VITALITY)
        {
        }
    }
}