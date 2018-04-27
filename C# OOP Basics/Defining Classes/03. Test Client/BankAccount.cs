using System;
using System.Collections.Generic;
using System.Text;

public class BankAccount
{
    public int Id { get; set; }
    public static decimal Balance { get; set; }

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
            Console.WriteLine($"Insufficient balance");
        }
    }
    public override string ToString()
    {
        return $"Account ID{Id}, balance {Balance:f2}";
    }
}
