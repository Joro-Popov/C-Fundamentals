public abstract class FoodFactory
{
    public static Food GetFood(string food)
    {
        switch (food.ToLower())
        {
            case "cram": return new Cram();
            case "lembas": return new Lembas();
            case "Apple": return new Apple();
            case "melon": return new Melon();
            case "honeycake": return new HoneyCake();
            case "mushroom": return new Mushroom();
            default: return new Other();
        }
    }
}