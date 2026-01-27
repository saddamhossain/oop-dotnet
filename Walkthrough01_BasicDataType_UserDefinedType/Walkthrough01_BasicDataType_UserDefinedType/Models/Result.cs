namespace Walkthrough01_BasicDataType_UserDefinedType.Models;

public class Result
{
    private const double PassingThreshold = 80.0;
    private const int TotalSubjects = 3;

    public double Physics { get; set; }
    public double Chemistry { get; set; }
    public double Biology { get; set; }

    public double GetAverage()
    {
        return (Physics + Chemistry + Biology) / TotalSubjects;
    }

    public string GetPassOrFail()
    {
        if (GetAverage() >= PassingThreshold)
        {
            return "Pass";
        }
        else
        {
            return "Fail";
        }
    }
}