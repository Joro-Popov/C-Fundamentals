using InfernoInfinity.Attributes;
using InfernoInfinity.Contracts;
using InfernoInfinity.Core;

namespace InfernoInfinity.Commands
{
    public class Create : Command
    {
        [Inject]
        private IWeaponRepository repository;

        [Inject]
        private IWeaponFactory weaponFactory;

        public Create(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string rarityLevel = this.Data[1];
            string weaponName = this.Data[2];
            var weapon = this.weaponFactory.CreateWeapon(rarityLevel, weaponName);
            this.repository.AddWeapon(weapon);
            return string.Empty;
        }
    }
}