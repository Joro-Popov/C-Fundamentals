using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DungeonMaster
{
    private List<Character> party;
    private Stack<Item> pool;
    private CharacterFactory characterFactory;
    private ItemFactory itemFactory;

    private int lastSurvivorRounds;

    public DungeonMaster()
    {
        this.party = new List<Character>();
        this.pool = new Stack<Item>();
        this.characterFactory = new CharacterFactory();
        this.itemFactory = new ItemFactory();
        this.lastSurvivorRounds = 0;
    }

    public string JoinParty(string[] args)
    {
        var faction = args[0];
        var type = args[1];
        var name = args[2];

        if (faction != Faction.CSharp.ToString() && faction != Faction.Java.ToString())
        {
            throw new ArgumentException(string.Format(Constants.InvalidFaction,faction));
        }
        else if (type != "Warrior" && type != "Cleric")
        {
            throw new ArgumentException(string.Format(Constants.InvalidCharacterType, type));
        }

        var character = this.characterFactory.CreateCharacter(faction,type,name);

        this.party.Add(character);

        return string.Format(string.Format(Constants.SuccessfullRegistration, name));
    }

    public string AddItemToPool(string[] args)
    {
        var itemName = args[0];
        
        var item = this.itemFactory.CreateItem(itemName);

        this.pool.Push(item);

        return string.Format(string.Format(Constants.SuccessfullAddedItem, itemName));
    }

    public string PickUpItem(string[] args)
    {
        var characterName = args[0];

        var character = this.party.FirstOrDefault(c => c.Name == characterName);
        
        if (character == null)
        {
            throw new ArgumentException(string.Format(Constants.CharacterNotFound, characterName));
        }

        if (!this.pool.Any())
        {
            throw new InvalidOperationException(Constants.NoItemsInPool);
        }

        character.Bag.AddItem(this.pool.Peek());

        return string.Format(Constants.PickedUpItem, characterName, this.pool.Pop().GetType().Name);
    }

    public string UseItem(string[] args)
    {
        var characterName = args[0];
        var itemName = args[1];

        var character = this.party.FirstOrDefault(s => s.Name == characterName);

        if (character == null)
        {
            throw new ArgumentException(string.Format(Constants.CharacterNotFound, characterName));
        }

        var item = character.Bag.GetItem(itemName);

        character.UseItem(item);

        return string.Format(Constants.UseItem, characterName, itemName);
    }

    public string UseItemOn(string[] args)
    {
        var giverName = args[0];
        var recieverName = args[1];
        var itemName = args[2];

        var giver = this.party.FirstOrDefault(g => g.Name == giverName);
        var reciever = this.party.FirstOrDefault(r => r.Name == recieverName);

        if (giver == null)
        {
            throw new ArgumentException(string.Format(Constants.CharacterNotFound, giverName));
        }
        else if (reciever == null)
        {
            throw new ArgumentException(string.Format(Constants.CharacterNotFound, recieverName));
        }

        var itemToUse = giver.Bag.GetItem(itemName);

        giver.UseItemOn(itemToUse, reciever);

        return string.Format(Constants.UseItemOn, giverName, itemName, recieverName);
    }

    public string GiveCharacterItem(string[] args)
    {
        var giverName = args[0];
        var recieverName = args[1];
        var itemName = args[2];

        var giver = this.party.FirstOrDefault(g => g.Name == giverName);
        var reciever = this.party.FirstOrDefault(r => r.Name == recieverName);

        if (giver == null)
        {
            throw new ArgumentException(string.Format(Constants.CharacterNotFound, giverName));
        }
        else if (reciever == null)
        {
            throw new ArgumentException(string.Format(Constants.CharacterNotFound, recieverName));
        }

        var itemToGive = giver.Bag.GetItem(itemName);

        giver.GiveCharacterItem(itemToGive, reciever);

        return string.Format(Constants.GiveItem, giverName, recieverName, itemName);
    }

    public string GetStats()
    {
        var result = new StringBuilder();

        foreach (var character in this.party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
        {
            result.AppendLine(character.ToString());
        }

        return result.ToString().Trim();
    }

    public string Attack(string[] args)
    {
        var attackerName = args[0];
        var recieverName = args[1];
        var result = new StringBuilder();

        var attacker = this.party.FirstOrDefault(g => g.Name == attackerName);
        var reciever = this.party.FirstOrDefault(r => r.Name == recieverName);

        if (attacker == null)
        {
            throw new ArgumentException(string.Format(Constants.CharacterNotFound, attackerName));
        }
        else if (reciever == null)
        {
            throw new ArgumentException(string.Format(Constants.CharacterNotFound, recieverName));
        }
        else if (!(attacker is IAttackable))
        {
            throw new ArgumentException(string.Format(Constants.CannotAttack, attackerName));
        }

        (attacker as IAttackable).Attack(reciever);

        result.AppendLine(string.Format(Constants.AttackOutput, attackerName, recieverName, attacker.AbilityPoints, recieverName, reciever.Health, reciever.BaseHealth, reciever.Armor, reciever.BaseArmor));

        if (!reciever.IsAlive)
        {
            result.AppendLine(string.Format(Constants.DeadReciever, recieverName));
        }

        return result.ToString().Trim();
    }

    public string Heal(string[] args)
    {
        var healerName = args[0];
        var healingRecieverName = args[1];

        var healer = this.party.FirstOrDefault(g => g.Name == healerName);
        var reciever = this.party.FirstOrDefault(r => r.Name == healingRecieverName);

        if (healer == null)
        {
            throw new ArgumentException(string.Format(Constants.CharacterNotFound, healerName));
        }
        else if (reciever == null)
        {
            throw new ArgumentException(string.Format(Constants.CharacterNotFound, healingRecieverName));
        }
        else if (!(healer is IHealable))
        {
            throw new ArgumentException(string.Format(Constants.CannotHeal, healerName));
        }

        (healer as IHealable).Heal(reciever);

        return string.Format(Constants.Healoutput, healerName, healingRecieverName, healer.AbilityPoints, healingRecieverName, reciever.Health);
    }

    public string EndTurn(string[] args)
    {
        var result = new StringBuilder();

        foreach (var character in this.party.Where(c => c.IsAlive))
        {
            var healthBeforeRest = character.Health;
            character.Rest();
            var healthAfterRest = character.Health;

            result.AppendLine(string.Format(Constants.RestOutput, character.Name, healthBeforeRest, healthAfterRest));
        }

        if (this.party.Where(c => c.IsAlive).Count() <= 1)
        {
            this.lastSurvivorRounds++;
        }

        return result.ToString().Trim();
    }

    public bool IsGameOver()
    {
        if (this.lastSurvivorRounds > 1)
        {
            return true;
        }
        return false;
    }
}