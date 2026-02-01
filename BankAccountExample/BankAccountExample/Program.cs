using BankAccountExample;

BankAccount bankAccount1 = new("123456789", "John Doe", 1000.0);
bankAccount1.Deposit(500.0);
bankAccount1.Withdraw(200.0);

Console.WriteLine("Account Number: " + bankAccount1.AccountNumber);
Console.WriteLine("Account Holder: " + bankAccount1.AccountHolderName);
Console.WriteLine("Final Balance: " + bankAccount1.Balance);

BankAccount bankAccount2 = new("987654321", "Jane Smith", 2000.0);

bankAccount2.Deposit(1000.0);
try
{
    bankAccount2.Withdraw(-5000.0);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.WriteLine("\nAccount Number: " + bankAccount2.AccountNumber);
Console.WriteLine("Account Holder: " + bankAccount2.AccountHolderName);
Console.WriteLine("Final Balance: " + bankAccount2.Balance);