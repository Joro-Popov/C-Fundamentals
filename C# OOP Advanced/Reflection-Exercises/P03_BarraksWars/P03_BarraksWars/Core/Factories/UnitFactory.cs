namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            string typeName = $"_03BarracksFactory.Models.Units.{unitType}";

            var type = Type.GetType(typeName);

            var unit = (IUnit)Activator.CreateInstance(type);

            return unit;
        }
    }
}
