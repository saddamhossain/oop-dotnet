namespace Walkthrough01_BasicDataType_UserDefinedType.Helpers;

public static class FilePathHelper
{
    public static string GetCsvFilePath()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var projectRoot = FindProjectRoot(currentDirectory);
        
        if (projectRoot != null)
        {
            return Path.Combine(projectRoot, "Data", "students.csv");
        }
        
        return Path.Combine("Data", "students.csv");
    }

    private static string FindProjectRoot(string startDirectory)
    {
        var directory = new DirectoryInfo(startDirectory);
        
        while (directory != null)
        {
            if (directory.GetFiles("*.csproj").Length > 0)
            {
                return directory.FullName;
            }
            
            directory = directory.Parent;
        }
        
        return null;
    }
}
