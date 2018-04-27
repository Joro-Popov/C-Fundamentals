using InfernoInfinity.Contracts;
using System;

namespace InfernoInfinity.Factories
{
    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(string qualityLevel, string gemType)
        {
            var fullName = $"InfernoInfinity.Gems.{gemType}";

            var type = Type.GetType(fullName);

            var gem = (IGem)Activator.CreateInstance(type, new object[] { qualityLevel });

            return gem;
        }
    }
}