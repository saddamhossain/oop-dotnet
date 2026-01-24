Student student1 = new Student();
student1.name = "Saddam Hossain";
student1.email = "saddam@example.com";
student1.contactNumber = "111-1234";

Result result1 = new Result();
result1.physics = 85.5;
result1.chemistry = 92.3;
result1.biology = 78.2;

student1.result = result1;

Student student2 = new Student();
student2.name = "Rana";
student2.email = "rana@example.com";
student2.contactNumber = "111-5678";

Result result2 = new Result();
result2.physics = 88.0;
result2.chemistry = 56.5;
result2.biology = 91.0;

student2.result = result2;

void DisplayStudentInfo(Student student)
{
    Console.WriteLine("Name: " + student.name);
    Console.WriteLine("Email: " + student.email);
    Console.WriteLine("Contact Number: " + student.contactNumber);
    Console.WriteLine("Physics: " + student.result.physics);
    Console.WriteLine("Chemistry: " + student.result.chemistry);
    Console.WriteLine("Biology: " + student.result.biology);
    Console.WriteLine("Average: " + student.result.GetAverage());
    Console.WriteLine("Result: " + student.result.GetPassOrFail());
}

DisplayStudentInfo(student1);

Console.WriteLine("------");

DisplayStudentInfo(student2);