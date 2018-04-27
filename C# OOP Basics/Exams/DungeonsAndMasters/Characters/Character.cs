using System;

public abstract class Character : ICharacter
{
    private string name;
    private double health;
    private double armor;

    protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
    {
        this.Name = name;
        this.BaseHealth = health;
        this.Health = BaseHealth;
        this.BaseArmor = armor;
        this.armor = this.BaseArmor;
        this.AbilityPoints = abilityPoints;
        this.Bag = bag;
        this.Faction = faction;
        this.IsAlive = true;
    }

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(Constants.NullName);
            }
            this.name = value;
        }
    }

    public double BaseHealth { get; private set; }

    public double Health
    {
        get { return this.health; }
        private set
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > this.BaseHealth)
            {
                value = this.BaseHealth;
            }
            this.health = value;
        }
    }

    public double BaseArmor { get; private set; }

    public double Armor
    {
        get { return this.armor; }
        private set
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > this.BaseArmor)
            {
                value = this.BaseArmor;
            }
            this.armor = value;
        }
    }

    public double AbilityPoints { get; private set; }

    public Bag Bag { get; private set; }

    public Faction Faction { get; private set; }

    public bool IsAlive { get; private set; }

    public virtual double RestHealMultiplier => 0.2;

    public void GiveCharacterItem(Item item, Character character)
    {
        if (this.IsAlive && character.IsAlive)
        {
            character.ReceiveItem(item);
        }
        else
        {
            throw new InvalidOperationException(Constants.DeadCharacter);
        }
    }

    public void ReceiveItem(Item item)
    {
        if (this.IsAlive)
        {
            this.Bag.AddItem(item);
        }
        else
        {
            throw new InvalidOperationException(Constants.DeadCharacter);
        }
    }

    public void Rest()
    {
        if (this.IsAlive)
        {
            this.Health += (this.BaseHealth * this.RestHealMultiplier);
        }
        else
        {
            throw new InvalidOperationException(Constants.DeadCharacter);
        }
    }

    public void TakeDamage(double hitPoints)
    {
        if (this.IsAlive)
        {
            double leftPoints = hitPoints - this.Armor;

            this.Armor -= hitPoints;

            if (leftPoints > 0)
            {
                this.Health -= leftPoints;

                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                }
            }
        }
        else
        {
            throw new InvalidOperationException(Constants.DeadCharacter);
        }
    }

    public void UseItem(Item item)
    {
        if (this.IsAlive)
        {
            item.AffectCharacter(this);
        }
        else
        {
            throw new InvalidOperationException(Constants.DeadCharacter);
        }
    }

    public void UseItemOn(Item item, Character character)
    {
        if (this.IsAlive && character.IsAlive)
        {
            item.AffectCharacter(character);
        }
        else
        {
            throw new InvalidOperationException(Constants.DeadCharacter);
        }
    }

    public void HealCharacter(double healPoints)
    {
        if (this.IsAlive)
        {
            this.Health += healPoints;
        }
        else
        {
            throw new InvalidOperationException(Constants.DeadCharacter);
        }
    }

    public void AffectFromPoisonPotion(int damage)
    {
        this.Health -= damage;

        if (this.Health <= 0)
        {
            this.IsAlive = false;
        }
    }

    public void RestoreArmor()
    {
        if (this.IsAlive)
        {
            this.Armor = this.BaseArmor;
        }
        else
        {
            throw new InvalidOperationException(Constants.DeadCharacter);
        }
    }

    public override string ToString()
    {
        if (this.IsAlive)
        {
            return string.Format(Constants.CharacterToString, this.Name, this.Health, this.BaseHealth, this.Armor, this.BaseArmor, "Alive");
        }
        return string.Format(Constants.CharacterToString, this.Name, this.Health, this.BaseHealth, this.Armor, this.BaseArmor, "Dead");
    }
}