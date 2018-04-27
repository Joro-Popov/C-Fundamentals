using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    private static void Create(List<string>tokens,Dictionary<int,BankAccount> accounts)
    {
        int id = int.Parse(tokens[1]);

        if (!accounts.ContainsKey(id))
        {
            BankAccount acc = new BankAccount();
            acc.Id = id;
            accounts[id] = acc;
        }
        else
        {
            Console.WriteLine($"Account already exists");
        }
    }
    private static void Deposit(List<string> tokens,Dictionary<int,BankAccount> accounts)
    {
        int id = int.Parse(tokens[1]);
        int ammount = int.Parse(tokens[2]);

        if (accounts.ContainsKey(id))
        {
            accounts[id].Deposit(ammount);
        }
        else
        {
            Console.WriteLine($"Account does not exist");
        }
    }
    private static void Withdraw(List<string> tokens,Dictionary<int,BankAccount> accounts)
    {
        int id = int.Parse(tokens[1]);
        int ammount = int.Parse(tokens[2]);

        if (accounts.ContainsKey(id))
        {
            accounts[id].Withdraw(ammount);
        }
        else
        {
            Console.WriteLine($"Account does not exist");
        }
    }
    private static void Print(List<string> tokens, Dictionary<int,BankAccount> accounts)
    {
        int id = int.Parse(tokens[1]);

        if (accounts.ContainsKey(id))
        {
            Console.WriteLine(accounts[id]);
        }
        else
        {
            Console.WriteLine($"Account does not exist");
        }
    }
    public static void Main()
    {
        string input;
        var accounts = new Dictionary<int, BankAccount>();
        while ((input = Console.ReadLine()) != "End")
        {
            List<string> tokens = input
                .Split()
                .ToList();

            string command = tokens[0];
            int id = int.Parse(tokens[1]);

            switch (command)
            {
                case "Create": Create(tokens, accounts); break;
                case "Deposit": Deposit(tokens, accounts); break;
                case "Withdraw": Withdraw(tokens, accounts); break;
                case "Print": Print(tokens, accounts);break;
            }
        }
    }
}
