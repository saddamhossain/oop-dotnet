namespace Walkthrough01_BasicDataType_UserDefinedType.Services;

public class StudentService
{
    public List<Student> LoadFromJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }

        var jsonContent = File.ReadAllText(filePath);
        var students = JsonSerializer.Deserialize<List<Student>>(jsonContent);

        if (students == null || students.Count == 0)
        {
            throw new InvalidOperationException("No students found in the file.");
        }

        return students;
    }

    public bool IsValidStudent(Student student)
    {
        if (student == null) return false;

        if (string.IsNullOrWhiteSpace(student.Name)) return false;

        if (string.IsNullOrWhiteSpace(student.Email)) return false;

        if (student.Result == null) return false;

        if (student.Result.Physics < 0 || student.Result.Physics > 100) return false;

        if (student.Result.Chemistry < 0 || student.Result.Chemistry > 100) return false;

        if (student.Result.Biology < 0 || student.Result.Biology > 100) return false;

        return true;
    }

    public void DisplayStudent(Student student)
    {
        if (!IsValidStudent(student))
        {
            Console.WriteLine($"\n[Invalid Student Data: {student?.Name ?? "Unknown"}]");
            return;
        }

        Console.WriteLine($"\n{new string('=', 50)}");
        Console.WriteLine($"Name:       {student.Name}");
        Console.WriteLine($"Email:      {student.Email}");
        Console.WriteLine($"Contact:    {student.ContactNumber}");
        Console.WriteLine($"{new string('-', 50)}");
        Console.WriteLine($"Physics:    {student.Result.Physics}");
        Console.WriteLine($"Chemistry:  {student.Result.Chemistry}");
        Console.WriteLine($"Biology:    {student.Result.Biology}");
        Console.WriteLine($"Average:    {student.Result.GetAverage():F2}");
        Console.WriteLine($"Result:     {student.Result.GetPassOrFail()}");
        Console.WriteLine($"{new string('=', 50)}");
    }

    public void DisplayAllStudents(List<Student> students)
    {
        Console.WriteLine("\n*** STUDENT MANAGEMENT SYSTEM ***\n");

        foreach (var student in students)
        {
            DisplayStudent(student);
        }
    }
}