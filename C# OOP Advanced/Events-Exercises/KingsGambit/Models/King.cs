namespace KingsGambit
{
    using System;
    using Contracts;

    public class King : IAttackable
    {
        private IWriter writer;

        public King(string name, IWriter writer)
        {
            this.Name = name;
            this.writer = writer;
        }

        public string Name { get; private set; }

        public event EventHandler<EventArgs> UnderAttack;

        public void RespondToAttack()
        {
            this.writer.Write($"King {this.Name} is under attack!");
            OnAttack();
        }

        protected virtual void OnAttack()
        {
            this.UnderAttack?.Invoke(this, EventArgs.Empty);
        }
    }
}
