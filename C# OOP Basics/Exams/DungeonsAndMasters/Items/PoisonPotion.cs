using System;

public class PoisonPotion : Item
{
    private const int WEIGHT = 5;
    private const int HEALTH_DECREASEMENT = 20;

    public PoisonPotion() : base(WEIGHT)
    {
    }

    public override void AffectCharacter(Character character)
    {
        character.AffectFromPoisonPotion(HEALTH_DECREASEMENT);
    }
}