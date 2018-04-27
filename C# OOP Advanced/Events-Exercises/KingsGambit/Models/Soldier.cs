namespace KingsGambit.Models
{
    using System;
    using Contracts;

    public abstract class Soldier : ISoldier
    {
        protected Soldier(string name, IWriter writer, int hitsToDie)
        {
            this.Name = name;
            this.Writer = writer;
            this.HitsToDie = hitsToDie;
        }

        protected IWriter Writer { get; private set; }

        public string Name { get; }

        public int HitsToDie { get; private set; }

        public void TakeAttack()
        {
            this.HitsToDie--;
        }

        public abstract void OnAttackKing(object sender, EventArgs args);
    }
}
