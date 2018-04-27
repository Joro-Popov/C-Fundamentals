namespace InfernoInfinity.Weapons
{
    public class Knife : Weapon
    {
        private const int MIN_DAMAGE = 3;
        private const int MAX_DAMAGE = 4;
        private const int SOCKETS = 2;

        public Knife(string rarityLevel, string name)
            : base(rarityLevel, name, MIN_DAMAGE, MAX_DAMAGE, SOCKETS)
        {
        }
    }
}