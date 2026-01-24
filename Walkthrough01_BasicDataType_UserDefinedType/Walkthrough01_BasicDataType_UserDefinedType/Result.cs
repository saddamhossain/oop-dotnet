namespace Walkthrough01_BasicDataType_UserDefinedType;

public class Result
{
    private const double PassingThreshold = 80.0;
    private const int TotalSubjects = 3;

    public double physics;
    public double chemistry;
    public double biology;

    public double GetAverage()
    {
        return (physics + chemistry + biology) / TotalSubjects;
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