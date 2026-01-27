namespace Walkthrough01_BasicDataType_UserDefinedType.Validation;

public class StudentInputValidator
{
    private const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

    public string GetValidName()
    {
        while (true)
        {
            Console.Write("Enter name: ");
            var name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("[ERROR] Name is required. Please try again.");
                continue;
            }

            return name;
        }
    }

    public string GetValidEmail()
    {
        while (true)
        {
            Console.Write("Enter email: ");
            var email = Console.ReadLine();

            if (!IsValidEmail(email))
            {
                Console.WriteLine("[ERROR] Invalid email format. Please use format: example@domain.com");
                continue;
            }

            return email;
        }
    }

    public string GetContactNumber()
    {
        Console.Write("Enter contact number: ");
        return Console.ReadLine();
    }

    public double GetValidMarks(string subject)
    {
        while (true)
        {
            Console.Write($"Enter {subject} marks (0-100): ");
            var input = Console.ReadLine();

            if (!double.TryParse(input, out var marks))
            {
                Console.WriteLine($"[ERROR] Please enter a valid number for {subject} marks.");
                continue;
            }

            if (marks < 0 || marks > 100)
            {
                Console.WriteLine($"[ERROR] {subject} marks must be between 0 and 100. Please try again.");
                continue;
            }

            return marks;
        }
    }

    private bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        return Regex.IsMatch(email, EmailPattern);
    }
}