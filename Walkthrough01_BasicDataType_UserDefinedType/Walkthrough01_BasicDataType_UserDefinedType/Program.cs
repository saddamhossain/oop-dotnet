
var csvFilePath = FilePathHelper.GetCsvFilePath();

IStudentService studentService = new StudentService();

var consoleUI = new ConsoleUI(studentService, csvFilePath);

consoleUI.Run();