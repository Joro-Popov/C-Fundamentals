using System;

public class HealthPotion : Item
{
    private const int WEIGHT = 5;
    private const int HEALTH_INCREASEMENT = 20;

    public HealthPotion() : base(WEIGHT)
    {

    }

    public override void AffectCharacter(Character character)
    {
        character.HealCharacter(HEALTH_INCREASEMENT);
    }
}