namespace InfernoInfinity.Weapons
{
    public class Sword : Weapon
    {
        private const int MIN_DAMAGE = 4;
        private const int MAX_DAMAGE = 6;
        private const int SOCKETS = 3;

        public Sword(string rarityLevel, string name)
            : base(rarityLevel, name, MIN_DAMAGE, MAX_DAMAGE, SOCKETS)
        {
        }
    }
}