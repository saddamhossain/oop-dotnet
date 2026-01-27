namespace Walkthrough01_BasicDataType_UserDefinedType.UI;

public class ConsoleUI
{
    private readonly IStudentService _studentService;
    private readonly string _csvFilePath;

    public ConsoleUI(IStudentService studentService, string csvFilePath)
    {
        _studentService = studentService;
        _csvFilePath = csvFilePath;
    }

    public void Run()
    {
        while (true)
        {
            DisplayMenu();
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewStudent();
                    break;
                case "2":
                    ShowAllStudents();
                    break;
                case "3":
                    Console.WriteLine("\nExiting application. Goodbye!");
                    return;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("\n*** STUDENT MANAGEMENT SYSTEM ***");
        Console.WriteLine("1. Add a new student");
        Console.WriteLine("2. Show all students");
        Console.WriteLine("3. Exit");
        Console.Write("\nEnter your choice: ");
    }

    private void AddNewStudent()
    {
        try
        {
            Console.WriteLine("\n--- Add New Student ---");

            var inputValidator = new StudentInputValidator();

            var name = inputValidator.GetValidName();
            var email = inputValidator.GetValidEmail();
            var contactNumber = inputValidator.GetContactNumber();
            var physics = inputValidator.GetValidMarks("Physics");
            var chemistry = inputValidator.GetValidMarks("Chemistry");
            var biology = inputValidator.GetValidMarks("Biology");

            var student = new Student
            {
                Name = name,
                Email = email,
                ContactNumber = contactNumber,
                Result = new Result
                {
                    Physics = physics,
                    Chemistry = chemistry,
                    Biology = biology
                }
            };

            _studentService.AddStudent(_csvFilePath, student);

            var fullPath = Path.GetFullPath(_csvFilePath);
            Console.WriteLine($"\n[SUCCESS] Student '{name}' added successfully!");
            Console.WriteLine($"[INFO] Data saved to: {fullPath}");
            Console.WriteLine($"[INFO] File size: {new FileInfo(fullPath).Length} bytes");
        }

        catch (Exception ex)
        {
            Console.WriteLine($"\n[ERROR] {ex.Message}");
        }
    }

    private void ShowAllStudents()
    {
        try
        {
            var students = _studentService.GetAllStudents(_csvFilePath);
            DisplayAllStudents(students);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[ERROR] {ex.Message}");
        }
    }

    private void DisplayAllStudents(List<Student> students)
    {
        Console.WriteLine("\n*** STUDENT MANAGEMENT SYSTEM ***\n");

        if (students == null || students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        Console.WriteLine($"{"Name",-20} {"Email",-30} {"Contact",-15} {"Physics",8} {"Chemistry",9} {"Biology",8} {"Average",8} {"Result",6}");
        Console.WriteLine(new string('-', 120));

        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name,-20} {student.Email,-30} {student.ContactNumber,-15} {student.Result.Physics,8:F1} {student.Result.Chemistry,9:F1} {student.Result.Biology,8:F1} {student.Result.GetAverage(),8:F2} {student.Result.GetPassOrFail(),6}");
        }

        Console.WriteLine(new string('-', 120));
        Console.WriteLine($"Total Students: {students.Count}\n");
    }
}