namespace KingsGambit
{
    using System;
    using Contracts;
    using Models;

    public class RoyalGuard : Soldier
    {
        private const int HITS_TO_DIE = 3;

        public RoyalGuard(string name, IWriter writer) 
            : base(name, writer,HITS_TO_DIE)
        {

        }

        public override void OnAttackKing(object sender, EventArgs args)
        {
            this.Writer.Write($"Royal Guard {this.Name} is defending!");
        }
    }
}
