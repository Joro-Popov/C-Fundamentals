using System;
using System.Collections.Generic;
using System.Text;

public class BankAccount
{
    public int Id { get; set; }
    public decimal Balance { get; set; }

    public override string ToString()
    {
        return $"Account {Id}, balance {Balance}";
    }
}
