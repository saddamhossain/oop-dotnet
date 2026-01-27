namespace Walkthrough01_BasicDataType_UserDefinedType.Interfaces;

public interface IStudentService
{
    List<Student> GetAllStudents(string filePath);
    void AddStudent(string filePath, Student student);
}