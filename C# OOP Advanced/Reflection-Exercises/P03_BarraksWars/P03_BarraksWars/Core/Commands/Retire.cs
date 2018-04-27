using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;
using P03_BarraksWars.Attributes;

namespace P03_BarraksWars.Core.Commands
{
    public class Retire : Command
    {
        [Inject]
        private IRepository repository;

        public Retire(string[] data) 
            : base(data)
        {

        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            this.repository.RemoveUnit(unitType);
            string output = unitType + " retired!";
            return output;
        }
    }
}
