namespace CreditCardDemo;

public class Customer
{
    public string Name { get; set; }
    public int Age { get; set; }
    public CreditCard CreditCard { get; set; }

    public Customer(string name, int age, CreditCard creditCard)
    {
        Name = name;
        Age = age;
        CreditCard = creditCard;
    }

    public bool IsEligibleForCreditCard()
    {
        return Age >= 18;
    }
}