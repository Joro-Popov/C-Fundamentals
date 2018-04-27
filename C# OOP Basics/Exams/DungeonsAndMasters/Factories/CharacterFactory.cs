using System;

public class CharacterFactory : ICharacterFactory
{
    public Character CreateCharacter(string factionAsString, string characterType, string name)
    {
        Enum.TryParse(factionAsString, out Faction faction);
        
        switch (characterType)
        {
            case "Warrior": return new Warrior(name, faction);
            case "Cleric": return new Cleric(name, faction);
            default: throw new ArgumentException(string.Format(Constants.InvalidCharacterType,characterType));
        }
    }
}