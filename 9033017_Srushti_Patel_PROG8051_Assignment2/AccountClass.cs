using System;
using System.Collections.Generic;

public class Account
{
    public int AccountNumber { get; set; }
    public string AccountHolderName { get; set; }
    public double Balance { get; private set; }
    public double InterestRate { get; set; }
    private List<string> Transactions;

    public double TotalDeposits { get; private set; }
    public double TotalWithdrawals { get; private set; }

    public Account(int accountNumber, string accountHolderName, double initialBalance, double interestRate)
    {
        AccountNumber = accountNumber;
        AccountHolderName = accountHolderName;
        Balance = initialBalance;
        InterestRate = interestRate;
        Transactions = new List<string>();
    }

    // Deposite money to account

    public void Deposite(double amount)
    {
        Balance += amount;
        TotalDeposits += amount;
        Transactions.Add($"Deposited: {amount}");
    }

    //Withdraw money from account

    public void Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            TotalWithdrawals += amount;
            Transactions.Add($"Withdrew: {amount}");
        }
        else
        {
            Console.WriteLine("Insufficient Balance.");
        }

    }

    //Display all trasactions

    public void DisplayTransactions()
    {
        foreach (var transaction in Transactions)
        {
            Console.WriteLine(transaction);
        }
    }
}








