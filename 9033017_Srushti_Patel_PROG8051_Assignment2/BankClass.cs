using System.Collections.Generic;

public class Bank
{
    private List<Account> accounts;
   
    public Bank()
    {
        accounts = new List<Account>();
    }

    // Get an account by account number

    public Account RetrieveAccount(int accountNumber)
    {
        return accounts.Find(account => account.AccountNumber == accountNumber);
    }

    // Add new account in bank

    public void AddAccount(Account account) 
    {
        accounts.Add(account);
    }



}