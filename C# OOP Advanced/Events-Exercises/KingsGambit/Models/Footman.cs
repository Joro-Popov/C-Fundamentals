namespace KingsGambit
{
    using System;
    using Contracts;
    using KingsGambit.Models;

    public class Footman : Soldier
    {
        private const int HITS_TO_DIE = 2;

        public Footman(string name, IWriter writer) 
            : base(name, writer,HITS_TO_DIE)
        {

        }

        public override void OnAttackKing(object sender, EventArgs args)
        {
            this.Writer.Write($"Footman {this.Name} is panicking!");
        }
    }
}
