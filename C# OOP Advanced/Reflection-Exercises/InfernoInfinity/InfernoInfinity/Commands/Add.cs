using InfernoInfinity.Attributes;
using InfernoInfinity.Contracts;
using InfernoInfinity.Core;

namespace InfernoInfinity.Commands
{
    public class Add : Command
    {
        [Inject]
        private IGemFactory gemFactory;

        [Inject]
        private IWeaponRepository repository;

        public Add(string[] data) 
            : base(data)
        {

        }

        public override string Execute()
        {
            string weaponName = this.Data[1];
            int socket = int.Parse(this.Data[2]);
            string[] gemArgs = this.Data[3].Split();
            string quality = gemArgs[0];
            string gemType = gemArgs[1];
            IGem gem = this.gemFactory.CreateGem(quality, gemType);
            this.repository.AddGem(gem, weaponName, socket);
            return string.Empty;
        }
    }
}