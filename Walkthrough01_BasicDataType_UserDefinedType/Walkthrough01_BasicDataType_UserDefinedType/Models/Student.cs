namespace Walkthrough01_BasicDataType_UserDefinedType.Models;

public class Student
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("contactNumber")]
    public string ContactNumber { get; set; }

    [JsonPropertyName("result")]
    public Result Result { get; set; }
}