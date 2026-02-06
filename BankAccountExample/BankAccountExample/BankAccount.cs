namespace BankAccountExample;

public class BankAccount
{
    public string AccountNumber 
    { 
        get; 
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Account number cannot be empty.");
            }
            field = value;
        }
    }
    public string AccountHolderName { get; set; }
    public double Balance { get; private set; }

    public BankAccount()
    {
        AccountNumber = string.Empty;
        AccountHolderName = string.Empty;
        Balance = 0;
    }

    public BankAccount(string accountNumber, string accountHolderName, double initialBalance)
    {
        AccountNumber = accountNumber;
        AccountHolderName = accountHolderName;
        Balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.");
        }
        Balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive.");
        }
        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient funds.");
        }
        Balance -= amount;
    }
}