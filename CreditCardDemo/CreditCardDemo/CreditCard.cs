namespace CreditCardDemo;

public class CreditCard
{
    private const double MaxCreditLimit = 500000;
    private const double MaxCashWithdrawalPerTransaction = 50000;

    public string CardNumber { get; set; }
    public DateTime ExpirationDate { get; set; }
    public double CreditLimit { get; private set; }
    public double AvailableCredit { get; private set; }
    public bool AllowsOverpayment { get; set; }

    public CreditCard(string cardNumber, DateTime expirationDate, bool allowsOverpayment = false)
    {
        CardNumber = cardNumber;
        ExpirationDate = expirationDate;
        CreditLimit = MaxCreditLimit;
        AvailableCredit = MaxCreditLimit;
        AllowsOverpayment = allowsOverpayment;
    }

    public bool IsCardValid()
    {
        return ExpirationDate > DateTime.UtcNow;
    }

    public void MakeCashWithdrawal(double amount)
    {
        if (amount > MaxCashWithdrawalPerTransaction)
            throw new InvalidOperationException($"Cannot withdraw more than {MaxCashWithdrawalPerTransaction} per transaction.");

        if (amount > AvailableCredit)
            throw new InvalidOperationException("Insufficient credit for this withdrawal.");

        AvailableCredit -= amount;
    }

    public void MakePurchase(double amount)
    {
        if (amount > AvailableCredit)
            throw new InvalidOperationException("Insufficient credit for this purchase.");

        AvailableCredit -= amount;
    }

    public void MakeRepayment(double amount)
    {
        if (amount <= 0)
            throw new InvalidOperationException("Repayment amount must be positive.");

        double newAvailableCredit = AvailableCredit + amount;

        if (AllowsOverpayment)
        {
            AvailableCredit = newAvailableCredit;
        }
        else
        {
            AvailableCredit = Math.Min(newAvailableCredit, CreditLimit);
        }
    }

    public double GetOutstandingBalance()
    {
        return CreditLimit - AvailableCredit;
    }
}