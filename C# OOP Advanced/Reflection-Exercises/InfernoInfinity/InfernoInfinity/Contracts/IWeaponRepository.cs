using InfernoInfinity.Contracts;

namespace InfernoInfinity.Core
{
    public interface IWeaponRepository
    {
        void AddWeapon(IWeapon weapon);

        void AddGem(IGem gem, string weaponName, int socket);

        void RemoveGem(string weaponName, int socket);

        IWeapon GetWeapon(string weaponName);
    }
}