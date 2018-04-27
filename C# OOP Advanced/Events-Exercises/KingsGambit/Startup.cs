namespace KingsGambit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using KingsGambit.Core;

    public class Startup
    {
        public static void Main()
        {
            IWriter writer = new Writer();
            IReader reader = new Reader();
            string kingName = Console.ReadLine();
            var king = new King(kingName, writer);
            var soldiers = ReadSoldiers(writer);
            IInterpreter interpreter = new CommandInterpreter(king, soldiers);
            
            Engine engine = new Engine(interpreter, reader, writer);

            engine.Run();
        }

        private static  IEnumerable<ISoldier> ReadSoldiers(IWriter writer)
        {
            List<ISoldier> soldiers = new List<ISoldier>();

            var guards = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => new RoyalGuard(s,writer))
                .ToList();

            var footman = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => new Footman(s, writer));

            soldiers.AddRange(guards);
            soldiers.AddRange(footman);

            return soldiers;
        }
    }
}
