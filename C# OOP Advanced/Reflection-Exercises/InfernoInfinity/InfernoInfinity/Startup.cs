using InfernoInfinity.Contracts;
using InfernoInfinity.Core;
using InfernoInfinity.Data;
using InfernoInfinity.Factories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InfernoInfinity
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            IWeaponRepository weaponRepository = new WeaponRepository();
            IWeaponFactory weaponFactory = new WeaponFactory();
            IGemFactory gemFactory = new GemFactory();
            ICommandInterpreter interpreter = new CommandInterpreter(weaponRepository, weaponFactory, gemFactory);

            Engine engine = new Engine(interpreter);

            engine.Run();
        }
        
    }
}