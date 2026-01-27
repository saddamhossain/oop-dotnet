namespace Walkthrough01_BasicDataType_UserDefinedType.Mapping;

public class StudentCsvMap : ClassMap<StudentCsvDto>
{
    public StudentCsvMap()
    {
        Map(m => m.Name).Name("name");
        Map(m => m.Email).Name("email");
        Map(m => m.ContactNumber).Name("contactNumber");
        Map(m => m.Physics).Name("physics");
        Map(m => m.Chemistry).Name("chemistry");
        Map(m => m.Biology).Name("biology");
    }
}