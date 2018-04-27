using System;

public class Warrior : Character, IAttackable
{
    private const double BASE_HEALTH = 100;
    private const double BASE_ARMOMR = 50;
    private const double ABILITY_POINTS = 40;

    public  Warrior(string name,Faction faction) 
        : base(name, BASE_HEALTH, BASE_ARMOMR, ABILITY_POINTS, new Satchel(), faction)
    {
    }

    public void Attack(Character character)
    {
        if (this.IsAlive && character.IsAlive)
        {
            bool isSameCharacter = this.Name == character.Name;
            bool isSameFaction = this.Faction == character.Faction;

            if (isSameCharacter)
            {
                throw new InvalidOperationException(Constants.SelfAttack);
            }
            else if (isSameFaction)
            {
                throw new ArgumentException(string.Format(Constants.FriendlyFire, this.Faction.ToString()));
            }

            double hitPoints = this.AbilityPoints;

            character.TakeDamage(hitPoints);
        }
        else
        {
            throw new InvalidOperationException(Constants.DeadCharacter);
        }
    }
}