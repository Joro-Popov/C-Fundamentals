using System;

public class Startup
{
    private static void Main()
    {
        try
        {
            Pizza pizza = new Pizza(Console.ReadLine());
            Dough dough = new Dough(Console.ReadLine());
            pizza.Dough = dough;

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                Topping topping = new Topping(input);
                pizza.AddTopping(topping, pizza.Toppings);
            }
            Console.WriteLine(pizza);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}