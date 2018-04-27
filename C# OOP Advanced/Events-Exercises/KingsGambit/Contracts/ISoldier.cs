using System;

namespace KingsGambit
{
    public interface ISoldier
    {
        string Name { get; }

        int HitsToDie { get; }

        void OnAttackKing(object sender, EventArgs args);

        void TakeAttack();
    }
}