namespace InfernoInfinity.Contracts
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string rarityLEvel, string weaponName);
    }
}