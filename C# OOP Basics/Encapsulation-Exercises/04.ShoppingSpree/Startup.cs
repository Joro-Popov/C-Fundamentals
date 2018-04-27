using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static Dictionary<string, Person> CreatePersons(List<string> people)
    {
        var result = new Dictionary<string, Person>();

        foreach (var person in people)
        {
            List<string> info = person.Split('=').ToList();
            Person current = null;
            try
            {
                current = new Person(info[0], decimal.Parse(info[1]));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
            result[info[0]] = current;
        }
        return result;
    }

    public static Dictionary<string, Product> CreateProducts(List<string> products)
    {
        var result = new Dictionary<string, Product>();
        foreach (var prod in products)
        {
            List<string> info = prod.Split('=').ToList();
            Product current = null;
            try
            {
                current = new Product(info[0], decimal.Parse(info[1]));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
            result[info[0]] = current;
        }
        return result;
    }

    public static void PrintPersons(Dictionary<string, Person> persons)
    {
        foreach (var person in persons)
        {
            Console.WriteLine(person.Value);
        }
    }

    private static void Main()
    {
        List<string> peopleInput = Console.ReadLine()
            .Split(';', StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        List<string> productsInput = Console.ReadLine()
            .Split(';', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var persons = CreatePersons(peopleInput);
        var products = CreateProducts(productsInput);

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            List<string> tokens = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Person currentPerson = persons[tokens[0]];
            Product currentProduct = products[tokens[1]];

            if (currentPerson.Money >= currentProduct.Cost)
            {
                currentPerson.BuyProduct(currentProduct);
                Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
            }
            else
            {
                Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
            }
        }
        PrintPersons(persons);
    }
}