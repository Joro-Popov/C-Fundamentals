using System;

public class ItemFactory : IItemFactory
{
    public Item CreateItem(string itemName)
    {
        switch (itemName)
        {
            case "ArmorRepairKit": return new ArmorRepairKit();
            case "HealthPotion": return new HealthPotion();
            case "PoisonPotion": return new PoisonPotion();
            default: throw new ArgumentException(string.Format(Constants.InvalidItem, itemName));
        }
    }
}