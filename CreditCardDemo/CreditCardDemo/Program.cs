CreditCard card = new CreditCard("1234-5678-9876-5432", new DateTime(2026, 12, 31));

Customer customer = new Customer("Md. Saddam Hossain", 25, card);

if (customer.IsEligibleForCreditCard())
{
    Console.WriteLine($"{customer.Name} is eligible for a credit card.");

    if (card.IsCardValid())
    {
        Console.WriteLine("Credit card is valid.");

        try
        {
            card.MakeCashWithdrawal(40000);
            Console.WriteLine($"Cash withdrawal successful. Available credit: {card.AvailableCredit}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Cash withdrawal failed: {ex.Message}");
        }

        try
        {
            card.MakePurchase(150000);
            Console.WriteLine($"Purchase successful. Available credit: {card.AvailableCredit}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Purchase failed: {ex.Message}");
        }

        try
        {
            card.MakeRepayment(50000);
            Console.WriteLine($"Repayment successful. Available credit: {card.AvailableCredit}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Repayment failed: {ex.Message}");
        }
    }
    else
    {
        Console.WriteLine("Credit card is expired.");
    }
}
else
{
    Console.WriteLine($"{customer.Name} is not eligible for a credit card.");
}

Console.WriteLine($"Outstanding balance: {card.GetOutstandingBalance()}");
