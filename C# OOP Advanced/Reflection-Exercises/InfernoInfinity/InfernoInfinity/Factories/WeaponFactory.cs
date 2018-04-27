using InfernoInfinity.Contracts;
using System;
using System.Linq;

namespace InfernoInfinity.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string rarityLEvel, string weaponName)
        {
            string fullName = $"InfernoInfinity.Weapons.{rarityLEvel.Split().Skip(1).First()}";

            var type = Type.GetType(fullName);

            var weapon = (IWeapon)Activator.CreateInstance(type, new object[] { rarityLEvel, weaponName });

            return weapon;
        }
    }
}