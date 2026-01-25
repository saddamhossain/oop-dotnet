const string JsonFilePath = "Data/students.json";

try
{
    var studentService = new StudentService();

    var students = studentService.LoadFromJson(JsonFilePath);

    studentService.DisplayAllStudents(students);
}
catch (Exception ex)
{
    Console.WriteLine($"\n[ERROR] {ex.Message}");
}