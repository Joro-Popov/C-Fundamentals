using InfernoInfinity.Attributes;
using InfernoInfinity.Core;

namespace InfernoInfinity.Commands
{
    public class Remove : Command
    {
        [Inject]
        private IWeaponRepository repository;

        public Remove(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string weaponName = this.Data[1];
            int socket = int.Parse(this.Data[2]);
            this.repository.RemoveGem(weaponName, socket);

            return string.Empty;
        }
    }
}