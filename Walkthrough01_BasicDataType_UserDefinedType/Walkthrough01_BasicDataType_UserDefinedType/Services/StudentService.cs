namespace Walkthrough01_BasicDataType_UserDefinedType.Services;

public class StudentService : IStudentService
{
    public List<Student> GetAllStudents(string filePath)
    {
        var students = new List<Student>();

        if (!File.Exists(filePath))
        {
            return students;
        }

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            TrimOptions = TrimOptions.Trim,
            MissingFieldFound = null,
            BadDataFound = null
        };

        try
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, config);

            csv.Context.RegisterClassMap<StudentCsvMap>();

            var records = csv.GetRecords<StudentCsvDto>();
            foreach (var record in records)
            {
                students.Add(MapToStudent(record));
            }
        }
        catch
        {
            return students;
        }

        return students;
    }

    public void AddStudent(string filePath, Student student)
    {
        EnsureDirectoryExists(filePath);

        var fileInfo = new FileInfo(filePath);
        var needsHeader = !fileInfo.Exists || fileInfo.Length == 0;

        EnsureFileEndsWithNewLine(filePath);

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
            NewLine = Environment.NewLine
        };

        using var stream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read);
        using var writer = new StreamWriter(stream);
        using var csv = new CsvWriter(writer, config);
        csv.Context.RegisterClassMap<StudentCsvMap>();

        if (needsHeader)
        {
            csv.WriteHeader<StudentCsvDto>();
            csv.NextRecord();
        }

        var dto = MapToDto(student);
        csv.WriteRecord(dto);
        csv.NextRecord();

        writer.Flush();
        stream.Flush();
    }

    private void EnsureFileEndsWithNewLine(string filePath)
    {
        if (!File.Exists(filePath))
            return;

        var fileInfo = new FileInfo(filePath);
        if (fileInfo.Length == 0)
            return;

        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
        if (stream.Length > 0)
        {
            stream.Seek(-1, SeekOrigin.End);
            var lastByte = stream.ReadByte();

            if (lastByte != '\n' && lastByte != '\r')
            {
                stream.Seek(0, SeekOrigin.End);
                var newLineBytes = System.Text.Encoding.UTF8.GetBytes(Environment.NewLine);
                stream.Write(newLineBytes, 0, newLineBytes.Length);
            }
        }
    }

    private void EnsureDirectoryExists(string filePath)
    {
        var directory = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
    }

    private Student MapToStudent(StudentCsvDto dto)
    {
        return new Student
        {
            Name = dto.Name,
            Email = dto.Email,
            ContactNumber = dto.ContactNumber,
            Result = new Result
            {
                Physics = dto.Physics,
                Chemistry = dto.Chemistry,
                Biology = dto.Biology
            }
        };
    }

    private StudentCsvDto MapToDto(Student student)
    {
        return new StudentCsvDto
        {
            Name = student.Name,
            Email = student.Email,
            ContactNumber = student.ContactNumber,
            Physics = student.Result.Physics,
            Chemistry = student.Result.Chemistry,
            Biology = student.Result.Biology
        };
    }
}