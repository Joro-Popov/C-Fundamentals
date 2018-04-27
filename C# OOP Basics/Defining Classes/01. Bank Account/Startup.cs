using System;

public class Startup
{
    public static void Main()
    {
        BankAccount bankAccount = new BankAccount();
        bankAccount.Id = 1;
        bankAccount.Balance = 15;

        Console.WriteLine(bankAccount);
    }
}
