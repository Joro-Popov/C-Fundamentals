using _03BarracksFactory.Contracts;
using P03_BarraksWars.Attributes;

namespace P03_BarraksWars.Core.Commands
{
    public class Add : Command
    {
        [Inject]
        private IRepository repository;

        [Inject]
        private IUnitFactory unitFactory;
        
        public Add(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
