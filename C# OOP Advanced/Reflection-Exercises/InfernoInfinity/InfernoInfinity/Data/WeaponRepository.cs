using InfernoInfinity.Contracts;
using InfernoInfinity.Core;
using System.Collections.Generic;

namespace InfernoInfinity.Data
{
    public class WeaponRepository : IWeaponRepository
    {
        private IDictionary<string, IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new Dictionary<string, IWeapon>();
        }

        public void AddWeapon(IWeapon weapon)
        {
            string weaponName = weapon.Name;
            this.weapons[weaponName] = weapon;
        }

        public void AddGem(IGem gem, string weaponName, int socket)
        {
            if (this.weapons.ContainsKey(weaponName))
            {
                IWeapon weapon = this.weapons[weaponName];
                weapon.AddGemToSocket(socket, gem);
            }
        }

        public void RemoveGem(string weaponName, int socket)
        {
            if (this.weapons.ContainsKey(weaponName))
            {
                IWeapon weapon = this.weapons[weaponName];
                weapon.RemoveGemFromSocket(socket);
            }
        }

        public IWeapon GetWeapon(string weaponName)
        {
            IWeapon weapon = null;

            if (this.weapons.ContainsKey(weaponName))
            {
                weapon = this.weapons[weaponName];
            }
            return weapon;
        }
    }
}