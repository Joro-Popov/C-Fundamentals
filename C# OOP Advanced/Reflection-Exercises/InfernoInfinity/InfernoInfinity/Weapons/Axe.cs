namespace InfernoInfinity.Weapons
{
    public class Axe : Weapon
    {
        private const int MIN_DAMAGE = 5;
        private const int MAX_DAMAGE = 10;
        private const int SOCKETS = 4;

        public Axe(string rarityLevel, string name)
            : base(rarityLevel, name, MIN_DAMAGE, MAX_DAMAGE, SOCKETS)
        {
        }
    }
}