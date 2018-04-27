using System;
using System.Collections.Generic;
using System.Text;

public class BankAccount
{
    public int Id { get; set; }
    public decimal Balance { get; set; }
    
    public BankAccount(int id,int balance)
    {
        Id = id;
        Balance = balance;
    }
    public void Deposit(decimal ammount)
    {
        Balance += ammount;
    }
    public void Withdraw(decimal ammount)
    {
        if (Balance >= ammount)
        {
            Balance -= ammount;
        }
        else
        {
            Console.WriteLine($"Ïnsufficient balance");
        }
    }
    public override string ToString()
    {
        return $"Account ID{Id}, balance {Balance:f2}";
    }
}
