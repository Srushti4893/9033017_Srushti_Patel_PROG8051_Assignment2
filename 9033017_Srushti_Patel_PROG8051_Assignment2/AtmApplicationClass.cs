using System;

public class AtmApplication
{
    private Bank bank;
    public AtmApplication()
    {
        bank = new Bank();
    }

    // Start the Atm application
    public void Start()
    {
        bool running = true;
        while (running)
        {
            DisplayMainMenu();
            int choice = int.Parse(Console.ReadLine());

            switch (choice)

            {
                case 1:
                    CreateAccount();
                    break;
                case 2:
                    SelectAccount();
                    break;
                case 3:
                    Console.WriteLine("Do you want to exit? [y/n]");
                    string exitOption = Console.ReadLine();
                    if (exitOption.ToLower() == "y")
                    {
                        running = false;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Option.");
                    break;
            }
        }

        Console.WriteLine("Thank you for using ATM Application.");
    }

    



    // Display main menu

    private void DisplayMainMenu()
    {
        Console.WriteLine("\n==========Welcome To The ATM Application==========");
        Console.WriteLine("\nChoose the following options by the number associated with the options:");
        Console.WriteLine("\n1. Create Account");
        Console.WriteLine("2. Select Account");
        Console.WriteLine("3. Exit");
        
    }
        // Create New Account

        private void CreateAccount()
    {

        Console.WriteLine("\n==========Welcome to Create Account Menu==========");
        Console.WriteLine("\nEnter Account Holder Name:");
        string name = Console.ReadLine();

        Console.WriteLine("\nEnter Account Number (Account number must be between 100 and 1000):");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("\nEnter Initial Balance:");
        double balance = double.Parse(Console.ReadLine());

        Console.WriteLine("\nEnter Annual Interest Rate (must be less than 3.0%):");
        double interestRate = double.Parse(Console.ReadLine());

        Account newAccount = new Account(number, name, balance, interestRate);
        bank.AddAccount(newAccount);
        
        Console.WriteLine("\nAccount created successfully!");
    }

    // Select an existing account

    private void SelectAccount()
    {
        Console.WriteLine("\nEnter Account Number (between 100 and 1000):");
        int number = int.Parse(Console.ReadLine());
        Account account = bank.RetrieveAccount(number);

        if (account != null)
        {
            bool accountMenuRunning = true;
            while (accountMenuRunning) 
            {
                DisplayAccountMenu(account.AccountHolderName);
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"\nCurrent Balance: {account.Balance}");
                        break;
                    case 2:
                        Console.WriteLine("\nEnter the amount to deposite:");
                        double depositAmount = double.Parse(Console.ReadLine());
                        account.Deposite(depositAmount);
                        Console.WriteLine("Done!");
                        break;
                    case 3:
                        Console.WriteLine("\nEnter the amount to withdraw:");
                        double withdrawAmount = double.Parse(Console.ReadLine());
                        account.Withdraw(withdrawAmount);
                        Console.WriteLine("Done!");
                        break;
                    case 4:
                        DisplayAccountDetails(account);
                        break;
                    case 5:
                        accountMenuRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option.");
                        break;

                }
            }
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    // Display the Account Menu

    private void DisplayAccountMenu(string accountHolderName)
    {
        Console.WriteLine($"\nWelcome {accountHolderName}");
        Console.WriteLine("\nChoose the followig Options:");
        Console.WriteLine("\n1. Check Balance");
        Console.WriteLine("2. Deposit");
        Console.WriteLine("3. Withdraw");
        Console.WriteLine("4. Display Transactions");
        Console.WriteLine("5. Exit Account");
    }

    // Display account details including transactions

    private void DisplayAccountDetails(Account account) 
    {
        Console.WriteLine("\n==========Transaction==========");
        Console.WriteLine($"\nAccountNumber: {account.AccountNumber}");
        Console.WriteLine($"Account Name: {account.AccountHolderName}");
        Console.WriteLine($"Annual Interest Rate: {account.InterestRate}");
        Console.WriteLine($"Account Balance: {account.Balance}");
        Console.WriteLine($"Deposit: {account.TotalDeposits}");
        Console.WriteLine($"Withdrawal: {account.TotalWithdrawals}");
    
    
    
    }
}

