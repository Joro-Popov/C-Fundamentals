using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Create(List<string>tokens,Dictionary<int,BankAccount>accounts,int id)
    {
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine($"Account already exists");
        }
        else
        {
            BankAccount acc = new BankAccount(id,0);
            accounts[id] = acc;
        }
    }
    public static void Deposit(List<string> tokens, Dictionary<int, BankAccount> accounts,int id)
    {
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
    public static void Withdraw(List<string> tokens, Dictionary<int, BankAccount> accounts,int id)
    {
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
    public static void Print(List<string> tokens, Dictionary<int, BankAccount> accounts,int id)
    {
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
        var accounts = new Dictionary<int, BankAccount>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            List<string> tokens = input
                .Split()
                .ToList();

            string command = tokens[0];
            int id = int.Parse(tokens[1]);

            switch (command)
            {
                case "Create": Create(tokens, accounts,id); break;
                case "Deposit": Deposit(tokens, accounts,id); break;
                case "Withdraw": Withdraw(tokens, accounts,id); break;
                case "Print": Print(tokens, accounts,id); break;
            }
        }
    }
}
