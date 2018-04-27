namespace KingsGambit.Contracts
{
    using System;

    public interface IAttackable
    {
        event EventHandler<EventArgs> UnderAttack;

        void RespondToAttack();
        
    }
}
