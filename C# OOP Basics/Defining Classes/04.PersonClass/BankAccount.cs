using System;
using System.Collections.Generic;
using System.Text;

public class BankAccount
{
    public int Id { get; set; }
    public decimal Balance { get; set; }

    public void Deposit(decimal ammount)
    {
        Balance += ammount;
    }
    public void Withdraw(decimal ammount)
    {
        Balance -= ammount;
    }
    public override string ToString()
    {
        return $"Account {Id}, balance {Balance}";
    }
}
