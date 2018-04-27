using InfernoInfinity.Attributes;
using InfernoInfinity.Contracts;
using InfernoInfinity.Core;

namespace InfernoInfinity.Commands
{
    public class Print : Command
    {
        [Inject]
        private IWeaponRepository repository;

        public Print(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string weaponName = this.Data[1];

            return this.repository.GetWeapon(weaponName).ToString();
        }
    }
}