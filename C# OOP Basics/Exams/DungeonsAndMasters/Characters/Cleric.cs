using System;

public class Cleric : Character, IHealable
{
    private const double BASE_HEALTH = 50;
    private const double BASE_ARMOR = 25;
    private const double ABILITY_POINTS = 40;

    public Cleric(string name, Faction faction) 
        : base(name, BASE_HEALTH, BASE_ARMOR, ABILITY_POINTS, new Backpack(), faction)
    {
    }

    public override double RestHealMultiplier => 0.5;

    public void Heal(Character character)
    {
        if (this.IsAlive && character.IsAlive)
        {
            bool isNotSameFaction = this.Faction != character.Faction;

            if (isNotSameFaction)
            {
                throw new InvalidOperationException(Constants.DifferentFaction);
            }

            double healPoints = this.AbilityPoints;

            character.HealCharacter(healPoints);
        }
        else
        {
            throw new InvalidOperationException(Constants.DeadCharacter);
        }
    }
}