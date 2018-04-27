namespace KingsGambit.Core
{
    using KingsGambit.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandInterpreter : IInterpreter
    {
        private IAttackable king;
        private IEnumerable<ISoldier> soldiers;

        public CommandInterpreter(IAttackable king, IEnumerable<ISoldier> soldiers)
        {
            this.king = king;
            this.soldiers = soldiers;
            AssignToEvent(this.king, this.soldiers);
        }

        public void InterpreteCommand(string[] data)
        {
            string cmd = data[0];

            switch (cmd)
            {
                case "Attack":
                    king.RespondToAttack(); break;

                case "Kill":
                    string name = data[1];
                    var soldier = soldiers.FirstOrDefault(s => s.Name == name);
                    RemoveSoldier(king, soldier, soldiers);
                    break;
            }
        }

        private static void RemoveSoldier(IAttackable king, ISoldier soldier, IEnumerable<ISoldier> soldiers)
        {
            soldier.TakeAttack();

            if (soldier.HitsToDie == 0)
            {
                king.UnderAttack -= soldier.OnAttackKing;

                soldiers = soldiers.Where(s => s.Name != soldier.Name);
            }
        }

        private static void AssignToEvent(IAttackable king, IEnumerable<ISoldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                king.UnderAttack += soldier.OnAttackKing;
            }
        }
    }
}
